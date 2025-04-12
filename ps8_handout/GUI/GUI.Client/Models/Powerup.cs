namespace GUI.Client.Models
{
    /// <summary>
    ///     This class keeps track of the powerup objects the players can interact with in the game world.
    ///     Authors: Sydney Burt and Levi Hammond
    ///     Date: April 11, 2025
    /// </summary>
    public class Powerup
    {
        /// <summary>
        ///     The ID representing this powerup object.
        /// </summary>
        public int power { get; set; }

        /// <summary>
        ///     The point where this powerup object is drawn on the screen.
        /// </summary>
        public Point2D loc { get; set; }

        /// <summary>
        ///     The state of this powerup object; whether or not to draw it on the screen.
        /// </summary>
        public bool died { get; set; }

        /// <summary>
        ///     The default Powerup constructor the JSON strings can interact with.
        /// </summary>
        public Powerup()
        {
            this.power = 0;
            this.loc = new Point2D(0, 0);
            this.died = true;
        }
    }
}
