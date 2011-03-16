namespace GameOfLifeWinForms
{
    public interface CellVisitor
    {
        bool visit(Cell cell);
    }
}