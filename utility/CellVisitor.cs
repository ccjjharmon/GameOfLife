using GameOfLifeWinForms.application.model;

namespace GameOfLifeWinForms.utility
{
    public interface CellVisitor
    {
        bool visit(Cell cell);
    }
}