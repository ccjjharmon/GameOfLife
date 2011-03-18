using System.Drawing;

namespace GameOfLifeWinForms.application.model
{
    public interface CellMap
    {
        string get_count();
        void add(Cell cell);
        Cell get_cell(int x, int y);
        int get_neighbor_count_of(Cell cell);
        bool generation();
        void render(Graphics graphics);
        int width();
        int height();
    }
}