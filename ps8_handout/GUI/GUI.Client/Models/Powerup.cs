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
        private int _powerID;
        private Point2D _spawnPoint;
        private bool gameState;

        public Powerup()
        {

        }
        public Powerup(int id, Point2D point)
        {
            _powerID = id;
            this._spawnPoint = point;
            this.gameState = true;
        }

        public void consumePowerup()
        {
            this.gameState = false;
        }
    }
}
