using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.application.model
{
    public class DefaultCell : Cell
    {
        public CellState state { get; set; }
        public CellState next_state { get; set; }
        public CellState last_state { get; set; }
        public XY location { get; set; }
        private bool hasChanges;

        public bool hasChanged()
        {
            return hasChanges;   
        }

        public DefaultCell(int x, int y, CellState state)
        {
            this.state = state;
            next_state = CellState.Unknown;
            last_state = CellState.Unknown;
            this.location = location;
            location = new XY(x, y);
            hasChanges = false;
        }

        public bool accept(CellVisitor visitor)
        {
            return visitor.visit(this);
        }

        public void move_to_next()
        {
            hasChanges = state == next_state ? false : true;
            last_state = state;
            state = next_state;
            next_state = CellState.Unknown;
        }
    }
}