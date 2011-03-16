using System;

namespace GameOfLifeWinForms
{
    public class XY : IEquatable<XY>
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
            return (other.x == this.x && other.y == this.y);
        }
    }
}