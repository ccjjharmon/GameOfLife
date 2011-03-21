using System.Drawing;
using GameOfLifeWinForms.application.model;
using GameOfLifeWinForms.utility;

namespace GameOfLifeWinForms.core
{
    public class LineWorldProcessor : WorldProcessor
    {

        public LineWorldProcessor(int x_max, int y_max)
        {
            this.x_max = x_max;
            this.y_max = y_max;
        }
    }
}