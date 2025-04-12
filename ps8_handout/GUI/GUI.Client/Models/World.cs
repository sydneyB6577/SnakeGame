namespace GUI.Client.Models
{
    /// <summary>
    ///     This class represents all objects in the game.
    ///     Authors: Sydney Burt, Levi Hammond
    ///     Date: 4-9-25
    /// </summary>
    public class World
    {
        /// <summary>
        ///     The list of snake objects the world possesses
        /// </summary>
        public Dictionary<int, Snake> snakes = new Dictionary<int, Snake>();

        /// <summary>
        ///     The list of wall objects the world possesses
        /// </summary>
        public Dictionary<int, ObstacleWall> walls = new Dictionary<int, ObstacleWall>();

        /// <summary>
        ///     The list of powerup objects the world possesses
        /// </summary>
        public Dictionary<int, Powerup> powerups = new Dictionary<int, Powerup>();

        /// <summary>
        ///     The int to keep track of this instance of the player
        /// </summary>
        public int currentPlayerID;

        /// <summary>
        /// The size of a single side of the square world
        /// </summary>
        public int Size
        { get; set; }

        /// <summary>
        ///     The width of the world
        /// </summary>
        public int Width
            { get; set; }

        /// <summary>
        ///     The height of the world
        /// </summary>
        public int Height 
            { get; set; }

        /// <summary>
        ///     The default size of the world
        /// </summary>
        public World()
        {
            this.Size = Size;
        }

        /// <summary>
        ///     The first constructor to set the size of the world
        /// </summary>
        /// <param name="size"></param>
        public World(int size)
        {
            this.Size = size;
            currentPlayerID = -1;
        }
        
        /// <summary>
        ///     The second constructor to create a copy of a world object
        /// </summary>
        /// <param name="world"></param>
        public World(World world)
        {
            this.Size = world.Size;
            this.Width = world.Width;
            this.Height = world.Height;
            this.snakes = world.snakes;
            this.powerups = world.powerups;
            this.walls = world.walls;
            this.currentPlayerID = world.currentPlayerID;
        }

        /// <summary>
        ///     Returns the instance of a snake object's head to track an instance of the GUI
        /// </summary>
        /// <returns>A last point in a snake object</returns>
        public Point2D getPlayerHead()
        {
            return snakes[currentPlayerID].body.Last();
        }

        /// <summary>
        ///     Sets the instance of a player ID
        /// </summary>
        /// <param name="playerID"></param>
        public void setCurrentPlayerID(int playerID)
        {
            currentPlayerID = playerID;
        }
    }
}
