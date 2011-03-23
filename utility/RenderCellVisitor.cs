using System.Drawing;
using GameOfLifeWinForms.application.model;
using System.Collections;

namespace GameOfLifeWinForms.utility
{
    public class RenderCellVisitor : CellVisitor
    {
        public RenderCellVisitor(Graphics graphics, CellMap map, ColorAdapterDictionary color_adapters, int square_size)
        {
            this.color_adapters = color_adapters;
            this.graphics = graphics;
            this.map = map;
            this.square_size = square_size;
            counter = 0;
        }

        private ColorAdapterDictionary color_adapters;
        private static int counter;
        private CellMap map;
        private Graphics graphics;
        private int square_size;

        public bool visit(Cell cell)
        {
            if (cell.hasChanged())
            {
                ColorAdapter adapter = color_adapters.Get("Default");
                int neighbor_count = map.get_neighbor_count_of(cell);
                if (cell.state == CellState.Live)
                {
                    if (neighbor_count > 3) { adapter = color_adapters.Get("NoNeighbor"); }
                    if (neighbor_count == 3) adapter = color_adapters.Get("ThreeNeighbors");
                    if (neighbor_count == 2) adapter = color_adapters.Get("TwoNeighbors");
                    if (neighbor_count == 1) adapter = color_adapters.Get("OneNeighbor");
                    if (neighbor_count == 0) adapter = color_adapters.Get("NoNeighbor");
                }
                else if(cell.state == CellState.AlmostDead)
                {
                    adapter = color_adapters.Get("Dead");
                } 
                else
                {
                    adapter = color_adapters.Get("Dead");
                }

//                if (cell.location.x == 0 || cell.location.x == map.height() || 
//                    cell.location.y == 0 || cell.location.y == map.width()) adapter = color_adapters.Get("Side");
                graphics.FillPie(adapter.Brush(), cell.location.x * square_size, cell.location.y * square_size, square_size, square_size, 0, 360);
            } 
            return true;
        }
    }
}