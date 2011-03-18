using System.Drawing;
using GameOfLifeWinForms.application.model;

namespace GameOfLifeWinForms.utility
{
    public class RenderCellVisitor : CellVisitor
    {
        public RenderCellVisitor(Graphics graphics, CellMap map)
        {
            this.graphics = graphics;
            this.map = map;
        }

        private CellMap map;
        private Graphics graphics;
        private static Brush NoNeighbor = Brushes.OrangeRed;
        private static Brush OneNeighbor = Brushes.Yellow;
        private static Brush TwoNeighbors = Brushes.Orange;
        private static Brush ThreeNeighbors = Brushes.LightYellow;
        private static Brush MoreThanThreeNeighbors = Brushes.LightGreen;
        private static Brush AlmostDead = Brushes.DimGray;
        private static Brush Dead = Brushes.Black;
        private static Brush Default = Brushes.White;
        private static Brush Side = Brushes.White;


        public bool visit(Cell cell)
        {
            if (cell.hasChanged())
            {
                Brush brush = Default;
                int neighbor_count = map.get_neighbor_count_of(cell);
                if (cell.state == CellState.Live)
                {
                    if (neighbor_count > 3) { brush = NoNeighbor; }
                    if (neighbor_count == 3) brush = ThreeNeighbors;
                    if (neighbor_count == 2) brush = TwoNeighbors;
                    if (neighbor_count == 1) brush = OneNeighbor;
                    if (neighbor_count == 0) brush = NoNeighbor;
                }
                else if(cell.state == CellState.AlmostDead)
                {
                    brush = Dead;
                } 
                else
                {
                    brush = Dead;
                }
                //  TODO: trying to draw the sides ... but needs more work
                //if (cell.location.x == 0 || cell.location.x == map.height()) brush = Side;
                //if (cell.location.y == 0 || cell.location.y == map.width()) brush = Side;
                graphics.FillPie(brush, cell.location.x * 8, cell.location.y * 8,8, 8, 0, 360);
            } 
            return true;
        }
    }
}