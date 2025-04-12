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
        ///     The X value in a point object
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     The Y value in the point object
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     The default Point2D object that the JSON strings can interact with
        /// </summary>
        public Point2D()
        {

        }

        /// <summary>
        ///     A non-default constructor where you can manually set the values of X and Y
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Method to set a point without creating a new one
        /// </summary>
        /// <param name="x">The new X part of a point</param>
        /// <param name="y">The new Y part of a point</param>
        public void setPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Method to return this point object
        /// </summary>
        /// <returns>This point object</returns>
        public Point2D getPoint()
        {
            return this;
        }
    }
}
