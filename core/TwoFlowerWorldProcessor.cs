using System;
using System.Drawing;
using GameOfLifeWinForms.application.model;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.core
{
    public class TwoFlowerWorldProcessor : WorldProcessor
    {

        public TwoFlowerWorldProcessor(int x_max, int y_max) 
        {
            this.x_max = x_max;
            this.y_max = y_max;
        }

        public override void setup_map()
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

            map = new DefaultCellMap(array);
        }
    }
}