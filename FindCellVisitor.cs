using System;

namespace GameOfLifeWinForms
{
    public class FindCellVisitor : CellVisitor
    {
        public XY location_to_match { get; set; }

        public bool visit(Cell cell)
        {
            return (cell.location == this.location_to_match);
            
        }
    }
}