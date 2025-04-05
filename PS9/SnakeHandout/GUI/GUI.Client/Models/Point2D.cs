namespace GUI.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Point2D
    {
        private int x;
        private int y;

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
        /// <returns></returns>
        public Point2D getPoint()
        {
            return this;
        }
    }
}
