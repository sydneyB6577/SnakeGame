// Network Controller
//
// The purpose of this file is to create an instance
// of an object that will handle all necessary methods for our
// snake game so the GUI can focus on drawing.
//
// Authors: Sydney Burt, Levi Hammond
// Date: 4-11-25

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

    /// <summary>
    ///     The class to create an instance of a NetworkController object
    /// </summary>
    public class NetworkController
    {
        public NetworkConnection connection = new NetworkConnection(); // The connection to the server
        static World gameWorld = new World(); // The instance of the game world

        private int colorCounter;

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
        

        // Maybe make all of the movement handled in a single method to better fit JSON command movement lines.

        /// <summary>
        ///     Establishes a connection to the server and handles all of the JSON
        ///     strings that are send to and recieved by the server.
        /// </summary>
        public async void HandleConnect(string name, World world)
        {
            connection.Connect("localhost", 11000);

            IsConnected = true;

            connection.Send(name);
            int id = int.Parse(connection.ReadLine());
            world.setCurrentPlayerID(id);
            int size = int.Parse(connection.ReadLine());
            world.Size = size;
            world.Width = size;
            world.Height = size; // Send the first messages to the server and set up world object variables

            Random rnd = new Random(); // Create random numbers for the colors
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);

            string s = "rgb(" + r + ", " + g + ", " + b + " )"; // Create the random color

            try
            {
                while (true)
                {
                    //Read the message from the name box
                    var message = connection.ReadLine(); // world object

                    if (message != null && message.Contains("snake")) // check if the string contains the word snake
                    {
                        Snake? currentSnake = JsonSerializer.Deserialize<Snake>(message); // deserialize the snake object
                        currentSnake!.color = s;
                        if (currentSnake.ToString().Contains("\"died\":true"))
                        {
                            world.snakes.Remove(currentSnake.snake, out currentSnake);
                            Thread.Sleep(40);
                        }
                        world.snakes[currentSnake!.snake] = currentSnake;// add the snake object to the world's dictionary or update it
                    }
                    else if (message != null && message.Contains("wall"))
                    {
                        ObstacleWall? currentWall = JsonSerializer.Deserialize<ObstacleWall>(message);
                        world.walls[currentWall!.wall] = currentWall;
                    }
                    else if (message != null && message.Contains("power"))
                    {
                        Powerup? currentPowerup = JsonSerializer.Deserialize<Powerup>(message);
                        if (currentPowerup.ToString().Contains("\"died\":true"))
                        {
                            world.powerups.Remove(currentPowerup.power, out currentPowerup); // Remove from the list?
                        }
                        world.powerups[currentPowerup!.power] = currentPowerup;
                    }
                }
            }
            catch (Exception)
            {
                DisconnectServer();
            }
        }
    }
}

