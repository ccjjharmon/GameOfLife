using System;
using System.Collections;

namespace GameOfLifeWinForms
{
    public class CellMapUser
    {
    //    private CellMap map;

    //    public CellMapUser()
    //    {
    //        map = new HashCellMap(new Hashtable(), 10, 10);
    //    }

    //    public void generation()
    //    {
    //        throw new NotImplementedException();
    //        //CellVisitor touchvisitor = new TouchCellVisitor(map);
    //        //foreach (Cell cell in map.v.Values.ToList<Cell>())
    //        //{
    //        //    touchvisitor.visit(cell);
    //        //}
    //    }

    //    public void Add(Cell cell)
    //    {
    //        if (cell.location.x >= 0 && cell.location.y >= 0)
    //        {
    //            map.Add(cell.location.x, cell.location.y, cell);
    //        }
    //    }


    //    XY FindBy(XY matchingxy)
    //    {
    //        foreach (XY xy in map.Keys)
    //        {
    //            if (xy.Equals(matchingxy)) return xy;
    //        }
    //        return null;
    //    }

    //    public Cell GetCell(XY findxy)
    //    {
    //        XY xy = FindBy(findxy);
    //        if (xy == null)
    //        {
    //            Cell new_cell = new Cell(findxy, CellState.Dead);
    //            Add(new_cell);
    //            return new_cell;
    //        }
    //        else
    //        {
    //            return (Cell)map[xy];
    //        }
    //    }

    }
}