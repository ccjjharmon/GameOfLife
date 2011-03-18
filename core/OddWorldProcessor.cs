using System;
using System.Drawing;
using GameOfLifeWinForms.application.model;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.core
{
    public class OddWorldProcessor : WorldProcessor
    {
        CellMap map;
        CellVisitor visitor;
        public int x_max { get; set; }
        public int y_max { get; set; }

        public OddWorldProcessor(int x_max, int y_max)
        {
            this.x_max = x_max;
            this.y_max = y_max;
        }

        public void setup_map()
        {
            Random random = new Random();
            Cell[,] array = new Cell[x_max, y_max];

            for (int x = 0; x < x_max; x++)
                for (int y = 0; y < y_max; y++)
                {
                    CellState state = CellState.Dead;
                    if ((x +2 - y) % 4 == random.Next(1,3))
                    {
                        state = CellState.Live;
                    }
                    array[x, y] = new DefaultCell(x, y, state);
                }

            map = new DefaultCellMap(array);
        }

        public bool next_generation()
        {
            return map.generation();
        }

        public void render_map(Graphics graphics)
        {
            map.render(graphics);
        }

    }
}