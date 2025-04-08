namespace GUI.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class World
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Snake> snakes = new List<Snake>();
        
        /// <summary>
        ///
        /// </summary>
        public List<ObstacleWall> walls = new List<ObstacleWall>();
        
        /// <summary>
        /// 
        /// </summary>
        public List<Powerups> powerups = new List<Powerups>(); 

        /// <summary>
        /// 
        /// </summary>
        public int worldTopDimension { get; set; }  

        /// <summary>
        /// 
        /// </summary>
        public int worldBottomDimesnion { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public int worldLeftDimension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int worldRightDimension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public World()
        {

        }
    }
}
