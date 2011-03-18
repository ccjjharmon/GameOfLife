using GameOfLifeWinForms.application.model;

namespace GameOfLifeWinForms.utility
{
    public class TouchCellVisitor : CellVisitor
    {
        private CellMap map;
        public TouchCellVisitor(CellMap map)
        {
            this.map = map;
        }

        public bool visit(Cell cell)
        {
            int neighbors = map.get_neighbor_count_of(cell);
            bool changed = false;

            if (cell.state == CellState.Live)
            {
                if (neighbors < 2)
                {
                    changed = true;
                    cell.next_state = CellState.AlmostDead;
                }
                if (neighbors == 2 || neighbors == 3) cell.next_state = CellState.Live;
                if (neighbors > 3)
                {
                    changed = true;
                    cell.next_state = CellState.AlmostDead;
                }
            }
            else
            {
                if (cell.state == CellState.AlmostDead)
                {
                    changed = true;
                    cell.next_state = CellState.Dead;
                }
                if (neighbors == 3) cell.next_state = CellState.Live;
            }
            return changed;
        }
    }
}