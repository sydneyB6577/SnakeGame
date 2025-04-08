namespace GUI.Client.Models
{
    /*
     * This class keeps track of all wall objects the players must avoid in the game world.
     * 
     * Authors: Sydney Burt, Levi Hammond.
     * Date: 4-2-25
     */
    public class ObstacleWall
    {
        /// <summary>
        ///     The ID to represent this wall object
        /// </summary>
        public int wall { get; set; }

        /// <summary>
        ///     The first endpoint where this wall object is drawn on the screen
        /// </summary>
        public Point2D p1 { get; set; }

        /// <summary>
        ///     The second endpoint where this wall object is drawn on the screen
        /// </summary>
        public Point2D p2 { get; set; }

        public ObstacleWall()
        {
            this.wall = 0;
            this.p1 = new Point2D(0, 0);
            this.p2 = new Point2D(1, 1);
        }
        //public ObstacleWall(int id, Point2D endPointOne, Point2D endPointTwo)
        //{
        //    this._wallID = id;
        //    this.endPointOne = endPointOne;
        //    this.endPointTwo = endPointTwo;
        //}
    }
}
