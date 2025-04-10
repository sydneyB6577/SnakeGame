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
        List<Color> colors = new List<Color>() {Color.Red, Color.Orange, Color.Yellow, Color.Green,
                                                Color.Blue, Color.Purple, Color.White, Color.Black};

        private int colorCounter = 0;


        // A list to keep track of all of the connections made to the game server.
        //static List<NetworkConnection> connectionList = new List<NetworkConnection>();

        // A list to keep track of all the players that connect to the game server for the snake names and other properties.
        //static Dictionary<Snake, NetworkConnection> players = new Dictionary<Snake, NetworkConnection>();

        //public static void Main(string[] args)
        //{
        //    Server
        //}

        // methods that define up down left and right movement

        // someone connecting to or exiting the game

        ///// <summary>
        ///// Method that establishes a connection to the server.
        ///// </summary>
        ///// <param name="handleConnect"></param>
        ///// <param name="port"></param>
        //public void ConnectToServer(Action<NetworkConnection> handleConnect, int port)
        //{
        //    connection.Connect(handleConnect, 11000);
        //}

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

        //May not be necessary due to separation of concerns.
        //public void playerDC(Snake snake)
        //{
        //snake.gameState = false;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name = "name"></param>
        /// THIS IS NOT ENOUGH. the message we're receiving is line by line and each line is an object
        /// need to check if line is wall, snake, or world, then act appripriately (update the entire world). 
        /// Don't deserialize the entire world.
        public static void HandleConnect(NetworkConnection connection, string name)
        {
            //Only adds the connection to the list if it is a new connection

            //Create a variable to hold the name of the chat member/connection.
            //Snake s = new Snake();

            // NOTE: We need to have methods in here to set a name for the snake, set the localhost, and the port.

            // NOTE: We call the methods in here inside the GUI.

            connection.Connect("localhost", 11000);

            connection.Send(name);

            try
            {
                while (true)
                {
                    //Read the message from the name box
                    var message = connection.ReadLine(); // world object

                    if (message != null && message.Contains("snake")) // check if the string contains the word snake
                    {
                        Snake? currentSnake = JsonSerializer.Deserialize<Snake>(message); // deserialize the snake object
                        SnakeGUI.TheWorld.snakes[currentSnake!.snake] = currentSnake; // add the snake object to the world's dictionary
                    }
                    else if (message != null && message.Contains("wall"))
                    {
                        ObstacleWall? currentWall = JsonSerializer.Deserialize<ObstacleWall>(message);
                        SnakeGUI.TheWorld.walls[currentWall!.wall] = currentWall;
                    }
                    else if (message != null && message.Contains("powerup"))
                    {
                        Powerup? currentPowerup = JsonSerializer.Deserialize<Powerup>(message);
                        SnakeGUI.TheWorld.powerups[currentPowerup!.power] = currentPowerup;
                    }

                    //If the snake is new, the first thing they type and submit is their game name.

                    //Send the message (and the snake's name) to every single connected snake.
                    //foreach (NetworkConnection socket in connectionList)
                    //{
                    //    //socket.Send(name + ": " + message);
                    //    //snake info JSON
                    //    JsonSerializer.Deserialize(message);

                    //    socket.Send(JsonSerializer.Serialize(s)); //Check to make sure this is working properly
                    //}
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

