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
        public int _wallID { get; set; }
        public Point2D endPointOne { get; set; }
        public Point2D endPointTwo { get; set; }

        public ObstacleWall()
        {

        }
        //public ObstacleWall(int id, Point2D endPointOne, Point2D endPointTwo)
        //{
        //    this._wallID = id;
        //    this.endPointOne = endPointOne;
        //    this.endPointTwo = endPointTwo;
        //}
    }
}
