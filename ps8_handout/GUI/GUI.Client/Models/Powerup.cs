namespace GUI.Client.Models
{

/// <summary>
///     This class keeps track of the powerup objects the players can interact with in the game world.
///     Authors: Sydney Burt, Levi Hammond.
///     Date: 4-9-25
/// </summary>
    public class Powerup
    {
        /// <summary>
        ///     The ID representing this powerup object
        /// </summary>
        public int power { get; set; }

        /// <summary>
        ///     The point where this powerup object is drawn on the screen
        /// </summary>
        public Point2D loc { get; set; }

        /// <summary>
        ///     The state of this powerpoint object for whether or not to draw it on the screen
        /// </summary>
        public bool died { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Powerup()
        {
            this.power = 0;
            this.loc = new Point2D(0, 0);
            this.died = true;
        }
        //public Powerup(int id, Point2D point)
        //{
        //    _powerID = id;
        //    this._spawnPoint = point;
        //    this.gameState = true;
        //}

        //public void consumePowerup()
        //{
        //    this.gameState = false;
        //}
    }
}
