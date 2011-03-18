using System.Drawing; 

namespace GameOfLifeWinForms.core
{
    public interface WorldProcessor
    {
        void setup_map();
        int x_max { get; set; }
        int y_max { get; set; }
        bool next_generation();
        void render_map(Graphics graphics);
    }
}