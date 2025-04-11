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
        /// 
        /// </summary>
        public Dictionary<int, Snake> snakes = new Dictionary<int, Snake>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, ObstacleWall> walls = new Dictionary<int, ObstacleWall>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, Powerup> powerups = new Dictionary<int, Powerup>();

        /// <summary>
        /// The size of a single side of the square world
        /// </summary>
        public int Size
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width
            { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height 
            { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public World()
        {
            this.Size = 1000;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public World(int size)
        {
            this.Size = size;
        }
        
        /// <summary>
        /// 
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
        }
    }
}
