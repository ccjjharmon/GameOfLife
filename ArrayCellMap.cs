using System;
using System.Drawing;

namespace GameOfLifeWinForms
{
    public class ArrayCellMap : CellMap
    {
        private Cell[,] array;

        public ArrayCellMap(Cell[,] array)
        {
            this.array = array;
        }
        public string get_count()
        {
            return (array.GetLength(0) + array.GetLength(1)).ToString();
        }

        public void Add(int x, int y, Cell cell)
        {
            if(x>=0 && y>=0) array[x,y] = cell;
        }

        public Cell GetCell(int x, int y)
        {
            Cell cell = null;
            if (x >= 0 && y >= 0 && x <= array.GetLength(0) && y <= array.GetLength(1)) cell= array[x, y];
            if (cell == null) cell = new DefaultCell(x, y, CellState.Dead);
            return cell;
        }

        public void generation()
        {
            CellVisitor touchvisitor = new TouchCellVisitor(this);
            Cell cell;
            for (int x = array.GetLowerBound(0); x < array.GetUpperBound(0); x++)
            {
                for (int y = array.GetLowerBound(1); y < array.GetUpperBound(1); y++)
                {
                    cell = array[x, y];
                    if(cell != null) touchvisitor.visit(cell);
                }
            }
            for (int x = array.GetLowerBound(0); x < array.GetUpperBound(0); x++)
            {
                for (int y = array.GetLowerBound(1); y < array.GetUpperBound(1); y++)
                {
                    cell = array[x, y];
                    if (cell != null) cell.move_to_next();
                }
            }
        }

        public void render(Graphics graphics)
        {
            CellVisitor visitor = new RenderCellVisitor(graphics);
            Cell cell;
            for (int x = array.GetLowerBound(0); x < array.GetUpperBound(0); x++)
            {
                for (int y = array.GetLowerBound(1); y < array.GetUpperBound(1); y++)
                {
                    cell = GetCell(x, y);
                    if (cell != null)
                    {
                        visitor.visit(cell);
                    } else
                    {
                        Console.WriteLine("no cell found to render");
                    }
                }
            }
        }
   }
}