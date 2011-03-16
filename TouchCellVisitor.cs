namespace GameOfLifeWinForms
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
            cell.map = this.map;
            return cell.touch();
        }
    }
}