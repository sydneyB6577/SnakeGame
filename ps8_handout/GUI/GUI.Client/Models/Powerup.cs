namespace GUI.Client.Models
{
    /*
     * This class keeps track of the powerup objects the players can interact with in the game world.
     * 
     * Authors: Sydney Burt, Levi Hammond.
     * Date: 4-2-25
     */
    public class Powerup
    {
        /// <summary>
        ///     The ID representing this powerup object
        /// </summary>
        public int _powerID { get; set; }

        /// <summary>
        ///     The point where this powerup object is drawn on the screen
        /// </summary>
        public Point2D _spawnPoint { get; set; }

        /// <summary>
        ///     The state of this powerpoint object for whether or not to draw it on the screen
        /// </summary>
        public bool gameState { get; set; }

        public Powerup()
        {
            this._powerID = 0;
            this._spawnPoint = new Point2D(0, 0);
            this.gameState = true;
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
