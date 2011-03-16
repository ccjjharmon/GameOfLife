using System;
using System.Drawing;

namespace GameOfLifeWinForms
{
    public class TwoFlowerWorld : World
    {
        CellMap map;
        CellVisitor visitor;
        private int x_max;
        private int y_max;

        public TwoFlowerWorld(int x_max, int y_max) 
        {
            this.x_max = x_max;
            this.y_max = y_max;
        }

        public void setup_map()
        {
            Cell[,] array = new Cell[x_max, y_max];
            Random rnd = new Random();

            for (int x = 0; x < x_max; x++)
                for (int y = 0; y < y_max; y++)
                {
                    CellState state = CellState.Dead;
                    if ((x)%3==rnd.Next(1, 2))
                    {
                        state = CellState.Live;
                    }
                    array[x, y] = new DefaultCell(x, y, state);
                }

            map = new ArrayCellMap(array);
        }

        public void execute_generation()
        {
            map.generation();
        }

        public void render_map(Graphics graphics)
        {
            map.render(graphics);
        }

    }
}