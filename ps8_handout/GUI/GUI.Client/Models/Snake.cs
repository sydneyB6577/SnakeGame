using System.Drawing;

namespace GUI.Client.Models
{
    /// <summary>
    ///     This class keeps track of the sname object the player uses to interact with the game world.
    ///     Authors: Sydney Burt, Levi Hammond
    ///     Date: 4-9-25
    /// </summary>
    public class Snake
    {
        /// <summary>
        ///     The ID of this snake object
        /// </summary>
        public int snake { get; set; }

        /// <summary>
        ///     The input name for this snake object   
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     List of Point2D points in the snake.
        ///     Tail is 1st point in the body point list.
        ///     Head is last point in the body point list.
        /// </summary>
        public List<Point2D> body {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D head { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point2D tail { get; set; }

        /// <summary>
        ///     The direction this snake object is traveling
        /// </summary>
        public Point2D dir { get; set; }

        /// <summary>
        ///     The score this snake object has scored during the game.
        /// </summary>
        public int score { get; set; }

        /// <summary>
        ///     The status of this snake object being dead or alive
        /// </summary>
        public bool died { get; set; }

        /// <summary>
        ///     The status of this snake object being dead or alive
        /// </summary>
        public bool alive { get; set; }

        /// <summary>
        ///     The status of this snake object being connected or disconnected
        /// </summary>
        public bool dc { get; set; }

        /// <summary>
        ///     The status of this snake object being connected or disconnected
        /// </summary>
        public bool join { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> colors = new List<string>() {"red", "orange", "yellow", "green",
                                                "blue", "purple", "white", "black"};

        /// <summary>
        /// 
        /// </summary>
        public Snake()
        {
            this.snake = 0;
            this.color = string.Empty;
            this.name = string.Empty;
            this.body = new List<Point2D>();
            this.head = new Point2D();
            this.tail = new Point2D();
            this.dir = new Point2D();
            this.score = 0;
            this.died = false;
            this.alive = true;
            this.dc = false;
            this.join = true;
        }
    }
}
