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
        private int _wallID;
        private Point2D endPointOne;
        private Point2D endPointTwo;

        public ObstacleWall()
        {

        }
        public ObstacleWall(int id, Point2D endPointOne, Point2D endPointTwo)
        {
            this._wallID = id;
            this.endPointOne = endPointOne;
            this.endPointTwo = endPointTwo;
        }
    }
}
