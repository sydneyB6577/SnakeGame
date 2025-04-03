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

        public Snake()
        {

        }

        public Snake(int iD, string name, List<Point2D> positionList, Point2D direction)
        {
            this._snakeID = iD;
            this._name = name;
            this._body = positionList;
            this._direction = direction;
            this._score = 0;
            this.gameState = true;
            this.serverState = true;
        }

        public void toggleGameState()
        {
            this.gameState = !this.gameState;
        }
        public void toggleServerState()
        {
            this.serverState = !this.serverState;
        }
        public void upScore()
        {
            this._score += 1;
        }
        public void changeDirection(Point2D direction)
        {
            this._direction = direction;
        }
        public void changePath(List<Point2D> path)
        {
            this._body = path;
        }
    }
}
