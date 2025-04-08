namespace GUI.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Powerups
    {
        /// <summary>
        /// 
        /// </summary>
        public int _powerID {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D _spawnPoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool gameState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Powerups()
        {
            this._powerID = 0;
            this._spawnPoint = new Point2D(0,0);
            this.gameState = true;
        }
    }
}
