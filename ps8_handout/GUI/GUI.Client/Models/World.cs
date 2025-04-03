namespace GUI.Client.Models
{
    public class World
    {
        private int worldTopDimention;
        private int worldBottomDimention;
        private int worldLeftDimention;
        private int worldRightDimention;

        public World(int x, int y)
        {
            this.worldTopDimention = x;
            this.worldBottomDimention = -x;
            this.worldLeftDimention = -y;
            this.worldRightDimention = y;
        }
    }
}
