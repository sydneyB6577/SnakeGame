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
        private Point2D _spawnPoint;

        public Powerup(Point2D point)
        {
            this._spawnPoint = point;
        }
    }
}
