using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLifeWinForms
{
    public class HashCellMap : CellMap
    {
        private Hashtable hashtable;
        private int x_max;
        private int y_max;

        public HashCellMap(Hashtable hash, int x_max, int y_max)
        {
            this.hashtable = hash;
            this.x_max = x_max;
            this.y_max = y_max;
        }

        public string get_count()
        {
            return hashtable.Count.ToString();
        }

        public void Add(int x, int y, Cell cell)
        {
            if (x >= 0 && x <= x_max && y >= 0 && y <= y_max)
            {
                hashtable.Add(build_key(x,y), cell);
            }
        }

        private object build_key(int x, int y)
        {
            return x.ToString("00") + y.ToString("00");
            //return new XY(x, y);
        }

        public Cell GetCell(int x, int y)
        {
            //foreach(Cell cell in hashtable.Values)
            //{
            //    if (cell.location.x == x && cell.location.y == y) return cell;
            //}
            //throw new NotImplementedException();
            return (Cell)hashtable[build_key(x, y)];
        }

        public void generation()
        {
            CellVisitor touchvisitor = new TouchCellVisitor(this);
            foreach (Cell cell in hashtable.Values)
            {
                touchvisitor.visit(cell);
            }
        }

        public void render(Graphics graphics)
        {
            CellVisitor visitor = new RenderCellVisitor(graphics);
            foreach(Cell cell in hashtable.Values)
            {
                visitor.visit(cell);
            }
            graphics.DrawString(get_count(), new Font("arial", 8), Brushes.Red, 10 * 5, 20 * 5);
        }
    }
}