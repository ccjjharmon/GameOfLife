using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameOfLifeWinForms.utility
{
    public class ColorAdapter
    {
        private Color color;

        public ColorAdapter(Color color)
        {
            this.color = color;
        }

        public void increment()
        {
            color = ColorTranslator.FromOle(ColorTranslator.ToWin32(color) + 0011);
        }

        public Brush Brush()
        {
            return new SolidBrush(color);
        }

      }
}
