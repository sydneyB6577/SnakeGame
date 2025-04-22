using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using GUI.Client.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

namespace GUI.Client.Controllers
{
    /// <summary>
    ///     The purpose of this class is to create an instance of an object that will handle
    ///     all necessary methods for our snake game so that the GUI class can focus on drawing.
    ///     
    ///     Authors: Sydney Burt and Levi Hammond
    ///     Date: April 22, 2025
    /// </summary>
    public class NetworkController
    {
        /// <summary>
        ///     The connection string to connect to the database used for the web server.
        ///     Sydney's uID login name serves as both the database name and the uid.
        ///     "sydney" (all lowercase) is the password.
        /// </summary>
        public const string connectDatabaseString = "server=atr.eng.utah.edu;" +
        "database=u1406577;" +
        "uid=u1406577;" +
        "password=sydney";

        private int gameID;

        /// <summary>
        ///     The connection to the server;
        /// </summary>
        public NetworkConnection connection = new NetworkConnection();

        //Creates strings to hold currentSnake.ToString() and currentPowerup.ToString(), even if they are null.
        private string? snakeString = string.Empty;
        private string? powerupString = string.Empty;

        /// <summary>
        ///     A list of all the snake ID's previously seen before.
        /// </summary>
        private List<int> IDList = new List<int>();

        /// <summary>
        ///     Determines whether the user is connected or not. 
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        ///     Calls the NetworkConnection Disconnect method to disconnect the user from the server.
        ///     Adds the time the game ended/player disconnected to the games table in the database.
        ///     Adds the time the game ended/player disconnected to the players table in the database.
        /// </summary>
        public void DisconnectServer()
        {
            //Get the time the game ended
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //Add the end time to the games table
            using (MySqlConnection SQLConnect = new MySqlConnection(connectDatabaseString))
            {
                SQLConnect.Open();
                using (MySqlCommand cmd = SQLConnect.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Games SET EndTime = " + "\"" + endTime + "\"" + $" WHERE GameID = {gameID};"; //Add a where statement?
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE Players SET LeaveTime = " + "\"" + endTime + "\"" + $" WHERE GameID = {gameID};"; //Add a where statement
                    cmd.ExecuteNonQuery();
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
        ///     Returns a string with all the information to connect to the snake database.
        /// </summary>
        /// <returns> A string with all the information to connect to the database. </returns>
        public string GetConnectionString()
        {
            return connectDatabaseString;
        }

        /// <summary>
        ///     Establishes a connection to the server and handles all of the JSON strings that are send to and recieved by the server.
        ///     Adds the game start time to the games table in the database.
        ///     Selects a new color for each snake.
        ///     Adds a row to the players table in the database with information about a new snake.
        ///     Updates the players table in the database with new high score information about previously seen snakes.
        /// </summary>
        public void HandleConnect(string name, World world)
        {
            //Connects to the server and host.
            connection.Connect("localhost", 11000);

            IsConnected = true;

            //Get the time the game started.
            string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            //Add a row to the games table with the start time of the game.
            using (MySqlConnection SQLConnect = new MySqlConnection(connectDatabaseString))
            {
                SQLConnect.Open();
                
                using (MySqlCommand cmd = SQLConnect.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Games(StartTime) VALUES (\"" + startTime + "\");"; // Set's up the query.
                    cmd.ExecuteNonQuery();
                }
               
                //Turns LAST_INSERT_ID into a variable so we can reference it
                MySqlCommand cmdTwo = SQLConnect.CreateCommand();
                cmdTwo.CommandText = "SELECT LAST_INSERT_ID();";
                using (MySqlDataReader reader = cmdTwo.ExecuteReader())
                {
                    reader.Read();
                    gameID = reader.GetInt32(0);
                }
            }

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

                    //Looks at snakes generated by the server and adds/updates them to the snake list.
                    if (message != null && message.Contains("snake"))
                    {
                        Snake? currentSnake = JsonSerializer.Deserialize<Snake>(message);
                        //Sets the color of the snake to a new, unique color.
                        currentSnake!.color = s;
                        snakeString = currentSnake.ToString();
                        //Removes the current snake from the world if it is dead.
                        if (snakeString!.Contains("\"died\":true"))
                        {
                            world.snakes.Remove(currentSnake.snake, out currentSnake);
                            Thread.Sleep(40);
                        }
                        //If the current snake identified by the server is not in the list, add their information to the players list.
                        if (!IDList.Contains(currentSnake!.snake))
                        {
                            using(MySqlConnection SQLConnectPlayer = new MySqlConnection(connectDatabaseString))
                            {
                                SQLConnectPlayer.Open();
                                using (MySqlCommand command = SQLConnectPlayer.CreateCommand())
                                {
                                    //Makes a new row in the players table with the new snake's id, name, entry time, and gameID
                                    command.CommandText = "INSERT INTO Players (PlayerID, PlayerName, EnterTime, GameID) VALUES (" + currentSnake.snake + "," + "\"" + currentSnake.name + "\"" + "," + "\"" + startTime + "\"" + "," + gameID + ");";
                                    command.ExecuteNonQuery();
                                }
                            }
                            IDList.Add(currentSnake!.snake);
                        }
                        //If the current snake identified by the server is already in the list, update the high score.
                        if(IDList.Contains(currentSnake!.snake))
                        {
                            if(currentSnake.score > currentSnake.maxScore)
                                currentSnake.maxScore = currentSnake.score;
                            
                            using (MySqlConnection SQLConnectPlayer = new MySqlConnection(connectDatabaseString))
                            {
                                SQLConnectPlayer.Open();
                                using (MySqlCommand command = SQLConnectPlayer.CreateCommand())
                                {
                                    //Updates a previously seen snake's max score only
                                    command.CommandText = "UPDATE Players SET PlayerMaxScore = " + currentSnake.maxScore + " WHERE GameID = " + gameID + ";";
                                    command.ExecuteNonQuery();
                                }
                            }
                            IDList.Add(currentSnake!.snake);
                        }
                        world.snakes[currentSnake!.snake] = currentSnake;
                    }
                    //Looks at walls generated by the server and adds/updates them to the wall list.
                    else if (message != null && message.Contains("wall"))
                    {
                        ObstacleWall? currentWall = JsonSerializer.Deserialize<ObstacleWall>(message);
                        world.walls[currentWall!.wall] = currentWall;
                    }
                    //Looks at powerups generated by the server and adds/updates them to the powerup list.
                    else if (message != null && message.Contains("power"))
                    {
                        Powerup? currentPowerup = JsonSerializer.Deserialize<Powerup>(message);
                        powerupString = currentPowerup!.ToString();
                        //Removes the current powerup from the world if it was eaten.
                        if (powerupString!.Contains("\"died\":true"))
                        {
                            world.powerups.Remove(currentPowerup.power, out currentPowerup);
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

