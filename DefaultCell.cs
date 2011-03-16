using System;

namespace GameOfLifeWinForms
{
    public class DefaultCell : Cell
    {
        public CellMap map { get; set; }
        public CellState state { get; set; }
        public CellState next_state { get; set; }
        public CellState last_state { get; set; }
        public XY location { get; set; }
        private bool hasChanges;

        public bool hasChanged()
        {
            return hasChanges;   
        }

        public DefaultCell(int x, int y, CellState state)
        {
            this.map = map;
            this.state = state;
            next_state = CellState.Unknown;
            last_state = CellState.Unknown;
            this.location = location;
            location = new XY(x, y);
            hasChanges = false;
        }

        public int get_neighbors()
        {
            int ct = 0;
            if (map.GetCell(location.x - 1, location.y).state == CellState.Live) ct++;
            if (map.GetCell(location.x - 1, location.y - 1).state == CellState.Live) ct++;
            if (map.GetCell(location.x - 1, location.y + 1).state == CellState.Live) ct++;
            if (map.GetCell(location.x, location.y - 1).state == CellState.Live) ct++;
            if (map.GetCell(location.x, location.y + 1).state == CellState.Live) ct++;
            if (map.GetCell(location.x + 1, location.y).state == CellState.Live) ct++;
            if (map.GetCell(location.x + 1, location.y - 1).state == CellState.Live) ct++;
            if (map.GetCell(location.x + 1, location.y + 1).state == CellState.Live) ct++;
            return ct;
        }

        public bool touch()
        {
            int neighbors = get_neighbors();

            if (this.state == CellState.Live)
            {
                if (neighbors < 2) next_state = CellState.AlmostDead;
                if (neighbors == 2 || neighbors == 3) next_state = CellState.Live;
                if (neighbors > 3) next_state = CellState.AlmostDead;
            }
            else
            {
                if (this.state == CellState.AlmostDead)
                {
                    next_state = CellState.Dead;
                }
                if (neighbors == 3) next_state = CellState.Live;
            }
            return true;
        }

        public void move_to_next()
        {
            hasChanges = state == next_state ? false : true;
            last_state = state;
            state = next_state;
            next_state = CellState.Unknown;
        }
    }
}