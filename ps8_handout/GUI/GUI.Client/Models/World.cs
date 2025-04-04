namespace GUI.Client.Models
{
    public class World
    {
        public int worldTopDimention { get; set; }
        public int worldBottomDimention { get; set; }
        public int worldLeftDimention { get; set; }
        public int worldRightDimention { get; set; }

        public World()
        {

        }

        //public World(int x, int y)
        //{
        //    this.worldTopDimention = x;
        //    this.worldBottomDimention = -x;
        //    this.worldLeftDimention = -y;
        //    this.worldRightDimention = y;
        //}
    }
}
