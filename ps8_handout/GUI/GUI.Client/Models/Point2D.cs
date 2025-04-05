namespace GUI.Client.Models
{
    /*
     * This class keeps track of all necessary points for all objects in the game world.
     * 
     * Authors: Sydney Burt, Levi Hammond.
     * Date: 4-2-25
     */
    public class Point2D
    {
        private int x;
        private int y;

        public Point2D()
        {

        }
        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D getPoint()
        {
            return this;
        }
    }
}
