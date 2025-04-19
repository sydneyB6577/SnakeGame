namespace GUI.Client.Controllers
{
    using System.Data;
    using System.Drawing;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.Json;
    using System.Xml.Linq;
    using CS3500.Networking;
    using GUI.Client.Models;
    using GUI.Client.Pages;
    using MySql.Data.MySqlClient;

    /// <summary>
    ///     The purpose of this class is to create an instance of an object that will handle
    ///     all necessary methods for our snake game so that the GUI class can focus on drawing.
    ///     
    ///     Authors: Sydney Burt and Levi Hammond
    ///     Date: April 11, 2025
    /// </summary>
    public class NetworkController
    {
        /// <summary>
        ///     The connection to the server;
        /// </summary>
        public NetworkConnection connection = new NetworkConnection();

        //Creating strings to hold currentSnake.ToString() and currentPowerup.ToString(), even 
        //if they are null.
        private string? snakeString = string.Empty;
        private string? powerupString = string.Empty;
        private List<int> IDList = new List<int>();

        /// <summary>
        ///     Determines whether the user is connected or not. 
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        ///     Calls the NetworConnection Disconnect method to disconnect the 
        ///     user from the server.
        /// </summary>
        public void DisconnectServer()
        {
            string connectDatabaseString = "user=u1406577;database=Sydney;password=sydney"; // Maybe?

            string leaveTime = DateTime.Now.ToString();

            using (MySqlConnection SQLConnect = new MySqlConnection(connectDatabaseString))
            {
                SQLConnect.Open();
                using (MySqlCommand cmd = SQLConnect.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Games(LeaveTime) VALUES (@leaveTime)"; // Set's up the query
                    cmd.Parameters.AddWithValue("@leaveTime", leaveTime); // Set the values to add to the game table
                }
            }

            connection.Disconnect();
            IsConnected = false;
        }

        /// <summary>
        ///     Instruction for upward movement in the game world.
        /// </summary>
        public void moveUP()
        {
            connection.Send("{\"moving\":\"up\"}");
        }

        /// <summary>
        ///     Instruction for downward movement in the game world.
        /// </summary>
        public void moveDOWN()
        {
            connection.Send("{\"moving\":\"down\"}");
        }

        /// <summary>
        ///     Instruction for left-hand movement in the game world.
        /// </summary>
        public void moveLEFT()
        {
            connection.Send("{\"moving\":\"left\"}");
        }

        /// <summary>
        ///     Instruction for right-hand movement in the game world.
        /// </summary>
        public void moveRIGHT()
        {
            connection.Send("{\"moving\":\"right\"}");
        }

        /// <summary>
        ///     Establishes a connection to the server and handles all of the JSON
        ///     strings that are send to and recieved by the server.
        /// </summary>
        public void HandleConnect(string name, World world)
        {
            //Connects to the server and host.
            connection.Connect("localhost", 11000);
            //Add a row to the Games table

            // Add a row to the games table

            // user: u1406577

            // database name: Sydney

            // password: sydney

            string connectDatabaseString = "user=u1406577;database=Sydney;password=sydney"; // Maybe?

            string enterTime = DateTime.Now.ToString();

            using (MySqlConnection SQLConnect = new MySqlConnection(connectDatabaseString))
            {
                SQLConnect.Open();
                using (MySqlCommand cmd = SQLConnect.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Games(EnterTime) VALUES (@enterTime)"; // Set's up the query 
                    cmd.Parameters.AddWithValue("@enterTime", enterTime); // Set the values to add to the game table
                }
            }

            IsConnected = true;

            // Sends the first messages to the server and sets up world object variables.
            connection.Send(name);
            int id = int.Parse(connection.ReadLine());
            world.setCurrentPlayerID(id);
            int size = int.Parse(connection.ReadLine());
            world.Size = size;
            world.Width = size;
            world.Height = size;

            //Creates random numbers for the rgb colors.
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);

            //Generates a random color for the snake.
            string s = "rgb(" + r + ", " + g + ", " + b + " )";

            try
            {
                while (true)
                {
                    //Read the message from the name box. Message is a world object.
                    var message = connection.ReadLine();

                    //Checks if the string contains the word snake
                    if (message != null && message.Contains("snake"))
                    {
                        //Deserializes the snake object.
                        Snake? currentSnake = JsonSerializer.Deserialize<Snake>(message);
                        //Sets the color of the snake to a new, unique color.
                        currentSnake!.color = s;
                        snakeString = currentSnake.ToString();
                        if (snakeString!.Contains("\"died\":true"))
                        {
                            world.snakes.Remove(currentSnake.snake, out currentSnake);
                            Thread.Sleep(40);
                        }
                        //Adds the snake object to the world's dictionary or updates it.
                        world.snakes[currentSnake!.snake] = currentSnake;
                    }
                    else if (message != null && message.Contains("wall"))
                    {
                        ObstacleWall? currentWall = JsonSerializer.Deserialize<ObstacleWall>(message);
                        world.walls[currentWall!.wall] = currentWall;
                    }
                    else if (message != null && message.Contains("power"))
                    {
                        Powerup? currentPowerup = JsonSerializer.Deserialize<Powerup>(message);
                        powerupString = currentPowerup!.ToString();
                        if (powerupString!.Contains("\"died\":true"))
                        {
                            world.powerups.Remove(currentPowerup.power, out currentPowerup); // Remove from the list?
                        }
                        world.powerups[currentPowerup!.power] = currentPowerup;
                    }
                }
            }
            catch (Exception)
            {
                //If the user clicks the disconnect button, disconnect them from the server.
                DisconnectServer();
            }
        }
    }
}

