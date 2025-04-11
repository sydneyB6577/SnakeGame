namespace GUI.Client.Models
{
    /// <summary>
    ///     This class represents all objects in the game.
    ///     Authors: Sydney Burt, Levi Hammond
    ///     Date: 4-9-25
    /// </summary>
    public class World
    {
        public Dictionary<int, Snake> snakes = new Dictionary<int, Snake>();
        public Dictionary<int, ObstacleWall> walls = new Dictionary<int, ObstacleWall>();
        public Dictionary<int, Powerup> powerups = new Dictionary<int, Powerup>();

        /// <summary>
        /// The size of a single side of the square world
        /// </summary>
        public int Size
        { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width
            { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height 
            { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public World()
        {
            this.Size = 1000;
        }

        public World(World world)
        {
            this.Size = world.Size;
        }
    }
}
