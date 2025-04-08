namespace GUI.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ObstacleWall
    {
        /// <summary>
        /// 
        /// </summary>
        public int _wallID {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D endPointOne { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D endPointTwo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ObstacleWall()
        {
            this._wallID = 0;
            this.endPointOne = new Point2D(0, 0);
            this.endPointTwo = new Point2D(1, 1);
        }
    }
}
