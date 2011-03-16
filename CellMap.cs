using System.Drawing;
using System.Linq;
using System;

namespace GameOfLifeWinForms
{
    public interface CellMap
    {
        string get_count();
        void Add(int x, int y, Cell cell);
        Cell GetCell(int x, int y);
        void generation();
        void render(Graphics graphics);
    }
}