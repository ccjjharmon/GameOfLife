using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.application.model
{
    public interface Cell
    {
        CellState state { get; set; }
        CellState last_state { get; set; }
        CellState next_state { get; set; }
        XY location { get; set; }
        bool accept(CellVisitor visitor);
        void move_to_next();
        bool hasChanged();
    }
}