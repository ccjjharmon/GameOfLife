using System.Drawing;

namespace GameOfLifeWinForms
{
    public interface World
    {
        void setup_map();
        void execute_generation();
        void render_map(Graphics graphics);
    }
}