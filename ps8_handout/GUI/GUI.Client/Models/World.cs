namespace GUI.Client.Models
{
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

        public int Width
            { get; private set; }

        public int Height 
            { get; private set; }

        public World()
        {
            this.Size = 1000;
        }

        //public World(int x, int y)
        //{
        //    this.worldTopDimention = x;
        //    this.worldBottomDimention = -x;
        //    this.worldLeftDimention = -y;
        //    this.worldRightDimention = y;
        //}
    }
}
