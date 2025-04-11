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
    using global::CS3500.Networking;
    using GUI.Client.Models;
    using GUI.Client.Pages;

    //namespace GUI.Client.Controllers
    //{

    /// <summary>
    /// 
    /// </summary>
    public class NetworkController
    {
        /// <summary>
        ///     
        /// </summary>
        public NetworkConnection connection = new NetworkConnection();
        static World gameWorld = new World();
        public List<Color> colors = new List<Color>() {Color.Red, Color.Orange, Color.Yellow, Color.Green,
                                                Color.Blue, Color.Purple, Color.White, Color.Black};

        private int colorCounter = 0;

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
            connection.Send("{\"moving\":\"up\"}\r\n");
        }

        /// <summary>
        ///     Instruction for downward movement in the game world.
        /// </summary>
        public void moveDOWN()
        {
            connection.Send("{\"moving\":\"up\"}\r\n");
        }

        /// <summary>
        ///     Instruction for left-hand movement in the game world.
        /// </summary>
        public void moveLEFT()
        {
            connection.Send("{\"moving\":\"up\"}\r\n");
        }

        /// <summary>
        ///     Instruction for right-hand movement in the game world.
        /// </summary>
        public void moveRIGHT()
        {
            connection.Send("{\"moving\":\"up\"}\r\n");
        }

        /// <summary>
        ///     Sets the snake to a new color for the first 8 snakes. After that, the colors are repeated.
        /// </summary>
        /// <param name="colors">A list of colors the method can choose from.</param>
        /// <returns>The color of the new snake.</returns>
        public Color setSnakeColor(List<Color> colors)
        {
            Color playerColor = colors[colorCounter];
            colorCounter++;
            colorCounter %= colors.Count;
            return playerColor;
        } 

        // Maybe make all of the movement handled in a single method to better fit JSON command movement lines.

        /// <summary>
        /// 
        /// </summary>
        /// THIS IS NOT ENOUGH. the message we're receiving is line by line and each line is an object
        /// need to check if line is wall, snake, or world, then act appripriately (update the entire world). 
        /// Don't deserialize the entire world.
        public void HandleConnect(string name, World world)
        {
            connection.Connect("localhost", 11000);
            IsConnected = true;

            connection.Send(name);
            int id = int.Parse(connection.ReadLine());
            int size = int.Parse(connection.ReadLine());
            world.Size = size;
            world.Width = size;
            world.Height = size;

            try
            {
                while (true)
                {
                    //Read the message from the name box
                    var message = connection.ReadLine(); // world object

                    if (message != null && message.Contains("snake")) // check if the string contains the word snake
                    {
                        Snake? currentSnake = JsonSerializer.Deserialize<Snake>(message); // deserialize the snake object
                        if (currentSnake.ToString().Contains("\"died\":true"))
                        {

                        }
                        world.snakes[currentSnake!.snake] = currentSnake; // add the snake object to the world's dictionary or update it
                    }
                    else if (message != null && message.Contains("wall"))
                    {
                        ObstacleWall? currentWall = JsonSerializer.Deserialize<ObstacleWall>(message);
                        world.walls[currentWall!.wall] = currentWall;
                    }
                    else if (message != null && message.Contains("powerup"))
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
                //If the chat member has disconnected from the chat, remove them from the dictionary.
                throw new Exception("YOU CAN'T DO THAT!");
            }
        }
    }
}
//}

