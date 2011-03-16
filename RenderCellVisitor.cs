using System;
using System.Drawing;

namespace GameOfLifeWinForms
{
    public class RenderCellVisitor : CellVisitor
    {
        public RenderCellVisitor(Graphics graphics)
        {
            this.graphics = graphics;
        }

        private Graphics graphics;
        private static Brush NoNeighbor = Brushes.OrangeRed;
        private static Brush OneNeighbor = Brushes.Yellow;
        private static Brush TwoNeighbors = Brushes.Orange;
        private static Brush ThreeNeighbors = Brushes.LightYellow;
        private static Brush MoreThanThreeNeighbors = Brushes.LightGreen;
        private static Brush AlmostDead = Brushes.DimGray;
        private static Brush Dead = Brushes.Black;
        private static Brush Default = Brushes.White;


        public bool visit(Cell cell)
        {
            if (cell.hasChanged())
            {
                Brush brush = Default;
                if (cell.state == CellState.Live)
                {
                    if (cell.get_neighbors() > 3) { brush = NoNeighbor; }
                    if (cell.get_neighbors() == 3) brush = ThreeNeighbors;
                    if (cell.get_neighbors() == 2) brush = TwoNeighbors;
                    if (cell.get_neighbors() == 1) brush = OneNeighbor;
                    if (cell.get_neighbors() == 0) brush = NoNeighbor;
                }
                else if(cell.state == CellState.AlmostDead)
                {
                    brush = Dead;
                } 
                else
                {
                    brush = Dead;
                }
                //graphics.DrawPie(new Pen(brush), cell.location.x * 5, cell.location.y * 5, 6, 6, 0, 360);
                graphics.FillPie(brush, cell.location.x * 8, cell.location.y * 8,8, 8, 0, 360);
            } 
            return true;
        }
    }
}