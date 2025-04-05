namespace GUI.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Snake
    {
        /// <summary>
        /// 
        /// </summary>
        public int _snakeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Point2D> _body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D _direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int _score { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public bool gameState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool serverState { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

    }
}
