using System;
using System.Drawing;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.application.model
{
    public class DefaultCellMap : CellMap
    {
        private Cell[,] array;

        public DefaultCellMap(Cell[,] array)
        {
            this.array = array;
        }
        public string get_count()
        {
            return (array.GetLength(0) + array.GetLength(1)).ToString();
        }

        public int width()
        {
            return array.GetLength(0);
        }

        public int height()
        {
            return array.GetLength(1);
        }

        public void add(Cell cell)
        {
            if (cell.location.x >= 0 && cell.location.y >= 0) array[cell.location.x, cell.location.y] = cell;
        }

        public int get_neighbor_count_of(Cell cell)
        {
            int ct = 0;
            if (get_cell(cell.location.x - 1, cell.location.y).state == CellState.Live) ct++;
            if (get_cell(cell.location.x - 1, cell.location.y - 1).state == CellState.Live) ct++;
            if (get_cell(cell.location.x - 1, cell.location.y + 1).state == CellState.Live) ct++;
            if (get_cell(cell.location.x, cell.location.y - 1).state == CellState.Live) ct++;
            if (get_cell(cell.location.x, cell.location.y + 1).state == CellState.Live) ct++;
            if (get_cell(cell.location.x + 1, cell.location.y).state == CellState.Live) ct++;
            if (get_cell(cell.location.x + 1, cell.location.y - 1).state == CellState.Live) ct++;
            if (get_cell(cell.location.x + 1, cell.location.y + 1).state == CellState.Live) ct++;
            return ct;
        }

        public Cell get_cell(int x, int y)
        {
            Cell cell = null;
            if (x >= 0 && y >= 0 && x <= array.GetLength(0) && y <= array.GetLength(1)) cell= array[x, y];
            if (cell == null) cell = new DefaultCell(x, y, CellState.Dead);
            return cell;
        }

        public bool generation()
        {
            CellVisitor touchvisitor = new TouchCellVisitor(this);
            Cell cell;
            int cells_changed = 0;
            for (int x = array.GetLowerBound(0); x < array.GetUpperBound(0); x++)
            {
                for (int y = array.GetLowerBound(1); y < array.GetUpperBound(1); y++)
                {
                    cell = array[x, y];
                    if(cell != null)
                    {
                        if (touchvisitor.visit(cell)) cells_changed++;
                    }
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
            return cells_changed > 10;
        }

        public void render(Graphics graphics)
        {
            CellVisitor visitor = new RenderCellVisitor(graphics, this);
            Cell cell;
            for (int x = array.GetLowerBound(0); x < array.GetUpperBound(0); x++)
            {
                for (int y = array.GetLowerBound(1); y < array.GetUpperBound(1); y++)
                {
                    cell = get_cell(x, y);
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