namespace GameOfLifeWinForms
{
    public interface Cell
    {
        CellState state { get; set; }
        CellState last_state { get; set; }
        XY location { get; set; }
        CellMap map { get; set; }
        bool touch();
        void move_to_next();
        int get_neighbors();
        bool hasChanged();
    }
}