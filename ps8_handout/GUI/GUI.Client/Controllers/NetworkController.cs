namespace GUI.Client.Controllers
{

    using System.Data;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.Json;
    using CS3500.Networking;
    using GUI.Client.Models;

    public class NetworkController
    {
        int upDown = 0;
        int leftRight = 0;

        // A list to keep track of all of the connections made to the game server.
        static List<NetworkConnection> connectionList = new List<NetworkConnection>();

        // A list to keep track of all the players that connect to the game server for the snake names and other properties.
        static Dictionary<Snake, NetworkConnection> players = new Dictionary<Snake, NetworkConnection>();

        //public static void Main(string[] args)
        //{
        //    Server
        //}

        // methods that define up down left and right movement

        // someone connecting to or exiting the game

        /// <summary>
        ///     Instruction for upward movement in the game world.
        /// </summary>
        /// <param name="snake"></param>
        public void moveUP(Snake snake)
        {
            upDown++;
            snake._direction = new Point2D(0, upDown);
        }

        /// <summary>
        ///     Instruction for downward movement in the game world.
        /// </summary>
        /// <param name="snake"></param>
        public void moveDOWN(Snake snake)
        {
            upDown--;
            snake._direction = new Point2D(0, upDown);
        }

        /// <summary>
        ///     Instruction for left-hand movement in the game world.
        /// </summary>
        /// <param name="snake"></param>
        public void moveLEFT(Snake snake)
        {
            leftRight--;
            snake._direction = new Point2D(leftRight, 0);
        }
        
        /// <summary>
        ///     Instruction for right-hand movement in the game world.
        /// </summary>
        /// <param name="snake"></param>
        public void moveRIGHT(Snake snake)
        {
            leftRight++;
            snake._direction = new Point2D(leftRight, 0);
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
        public static void HandleConnect(NetworkConnection connection) 
        {
            //Only adds the connection to the list if it is a new connection
            if (!connectionList.Contains(connection))
            {
                connectionList.Add(connection);
            }

            //Create a variable to hold the name of the chat member/connection.
            string? name = null;
            Snake s = new Snake();

            try
            {
                while (true)
                {
                    //Read the message from the name box
                    var message = connection.ReadLine();

                    //If the snake is new, the first thing they type and submit is their game name.
                    if (name == null)
                    {
                        name = message;
                        s._name = name;
                        players.Add(s, connection);
                        continue;
                    }

                    //Send the message (and the snake's name) to every single connected snake.
                    foreach (NetworkConnection socket in connectionList)
                    {
                        //socket.Send(name + ": " + message);
                        //snake info JSON
                        socket.Send(JsonSerializer.Serialize(s)); //Check to make sure this is working properly
                    }
                }
            }
            catch (Exception)
            {
                //If the chat member has disconnected from the chat, remove them from the dictionary.
                players.Remove(s);
            }
        }
    }
    }
}
