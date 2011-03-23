using System;
using System.Drawing;
using GameOfLifeWinForms.application.model;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.core
{
    public class GosperGliderGunWorldProcessor : WorldProcessor
    {

        public GosperGliderGunWorldProcessor(int x_max, int y_max, Graphics graphics, int square_size)
        {
            this.x_max = x_max;
            this.y_max = y_max;
            this.graphics = graphics;
            this.square_size = square_size;
        }

        public override void setup_map()
        {
            Cell[,] array = new Cell[x_max, y_max];
            Random rnd = new Random();

            for (int x = 0; x < x_max; x++)
                for (int y = 0; y < y_max; y++)
                    array[x, y] = new DefaultCell(x, y, CellState.Dead);
            array[1, 5].state = CellState.Live;
            array[2, 5].state = CellState.Live;
            array[1, 6].state = CellState.Live;
            array[2, 6].state = CellState.Live;

            array[11, 5].state = CellState.Live;
            array[11, 6].state = CellState.Live;
            array[11, 7].state = CellState.Live;
            array[12, 4].state = CellState.Live;
            array[13, 3].state = CellState.Live;
            array[14, 3].state = CellState.Live;
            array[12, 8].state = CellState.Live;
            array[13, 9].state = CellState.Live;
            array[14, 9].state = CellState.Live;
            array[15, 6].state = CellState.Live;
            array[16, 4].state = CellState.Live;
            array[16, 8].state = CellState.Live;
            array[17, 5].state = CellState.Live;
            array[17, 6].state = CellState.Live;
            array[17, 7].state = CellState.Live;
            array[18, 6].state = CellState.Live;

            array[21, 3].state = CellState.Live;
            array[21, 4].state = CellState.Live;
            array[21, 5].state = CellState.Live;
            array[22, 3].state = CellState.Live;
            array[22, 4].state = CellState.Live;
            array[22, 5].state = CellState.Live;
            array[23, 2].state = CellState.Live;
            array[23, 6].state = CellState.Live;
            array[25, 1].state = CellState.Live;
            array[25, 2].state = CellState.Live;
            array[25, 6].state = CellState.Live;
            array[25, 7].state = CellState.Live;

            array[35, 3].state = CellState.Live;
            array[35, 4].state = CellState.Live;
            array[36, 3].state = CellState.Live;
            array[36, 4].state = CellState.Live;

            map = new DefaultCellMap(array, square_size);


        }
    }
}