namespace GUI.Client.Models
{
    /// <summary>
    ///     This class keeps track of all necessary points for all objects in the game world.
    ///     Authors: Sydney Burt, Levi Hammond.
    ///     Date: 4-2-25
    /// </summary>
    public class Point2D
    {

        /// <summary>
        /// 
        /// </summary>
        public int x;

        /// <summary>
        /// 
        /// </summary>
        public int y;

        /// <summary>
        /// 
        /// </summary>
        public Point2D()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void setPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point2D getPoint()
        {
            return this;
        }
    }
}
