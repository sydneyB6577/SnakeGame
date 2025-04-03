namespace GUI.Client.Models
{
    /*
     * This class keeps track of the snake object the player uses to interact with the game world.
     * 
     * Authors: Sydney Burt, Levi Hammond.
     * Date: 4-2-25
     */
    public class Snake
    {
        private int _snakeID;
        private string _name;
        private List<Point2D> _body;
        private Point2D _direction;
        private int _score;
        private bool gameState;
        private bool serverState;

        public Snake(int iD, string name)
        {

        }
    }
}
