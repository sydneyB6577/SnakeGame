namespace GUI.Client.Models
{
    public class World
    {
        public Dictionary<int, Snake> snakes = new Dictionary<int, Snake>();
        public Dictionary<int, ObstacleWall> walls = new Dictionary<int, ObstacleWall>();
        public Dictionary<int, Powerup> powerups = new Dictionary<int, Powerup>();

        /// <summary>
        ///     The upper side of this world object to draw the gameplay area
        /// </summary>
        public int worldTopDimention { get; set; }

        /// <summary>
        ///     The lower side of this world object to draw the gameplay area
        /// </summary>
        public int worldBottomDimention { get; set; }

        /// <summary>
        ///     The left-hand side of this world object to draw the gameplay area
        /// </summary>
        public int worldLeftDimention { get; set; }

        /// <summary>
        ///     The right-hand side of this world object to draw the gameplay area
        /// </summary>
        public int worldRightDimention { get; set; }

        public World()
        {
            this.worldTopDimention = 0;
            this.worldBottomDimention = 0;
            this.worldLeftDimention = 0;
            this.worldRightDimention = 0;
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
