namespace GUI.Client.Models
{
    public class World
    {
        public List<Snake> snakes = new List<Snake>();
        public List<ObstacleWall> walls = new List<ObstacleWall>();
        public List<Powerup> powerups = new List<Powerup>();

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
