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
        /// <summary>
        ///     The ID of this snake object
        /// </summary>
        public int _snakeID { get; set; }

        /// <summary>
        ///     The input name for this snake object   
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        ///     The list of objects to draw for this snake object's representation
        /// </summary>
        public List<Point2D> _body { get; set; }

        /// <summary>
        ///     The direction this snake object is traveling
        /// </summary>
        public Point2D _direction { get; set; }

        /// <summary>
        ///     The score this snake object has scored during the game.
        /// </summary>
        public int _score { get; set; }

        /// <summary>
        ///     The status of this snake object being dead or alive
        /// </summary>
        public bool gameState { get; set; }

        /// <summary>
        ///     The status of this snake object being connected or disconnected
        /// </summary>
        public bool serverState { get; set; }

        public Snake()
        {
            this._snakeID = 0;
            this._name = string.Empty;
            this._body = new List<Point2D>();
            this._direction = new Point2D();
            this._score = 0;
            gameState = true;
            serverState = true;
        }
        //public Snake(int iD, string name, List<Point2D> positionList, Point2D direction)
        //{
        //    this._snakeID = iD;
        //    this._name = name;
        //    this._body = positionList;
        //    this._direction = direction;
        //    this._score = 0;
        //    this.gameState = true;
        //    this.serverState = true;
        //}

        //public void toggleGameState()
        //{
        //    this.gameState = !this.gameState;
        //}
        //public void toggleServerState()
        //{
        //    this.serverState = !this.serverState;
        //}
        //public void upScore()
        //{
        //    this._score += 1;
        //}
        //public void changeDirection(Point2D direction)
        //{
        //    this._direction = direction;
        //}
        //public void changePath(List<Point2D> path)
        //{
        //    this._body = path;
        //}
    }
}
