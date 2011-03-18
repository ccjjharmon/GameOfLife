namespace GameOfLifeWinForms.application.model
{
    public class XY : System.IEquatable<XY>
    {
        public int x;
        public int y;

        public XY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(XY other)
        {
            return (other.x == x && other.y == y);
        }

    }
}