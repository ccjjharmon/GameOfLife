using System.Drawing;
using GameOfLifeWinForms.application.model;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.core
{
    public class SlashWorldProcessor : WorldProcessor
    {

        public SlashWorldProcessor(int x_max, int y_max, Graphics graphics, int square_size) 
        {
            this.x_max = x_max;
            this.y_max = y_max;
            this.graphics = graphics;
            this.square_size = square_size;
        }

        public override void setup_map()
        {
            Cell[,] array = new Cell[x_max, y_max];

            for (int x = 0; x < x_max; x++)
                for (int y = 0; y < y_max; y++)
                {
                    CellState state = CellState.Dead;
                    if ((x-y)%2==1 )
                    {
                        state = CellState.Live;
                    }
                    array[x, y] = new DefaultCell(x, y, state);
                }

            map = new DefaultCellMap(array, square_size);


        }
    }
}