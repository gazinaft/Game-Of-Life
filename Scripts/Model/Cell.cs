namespace GameOfLife.Scripts.Model
{
    public class Cell
    {
        public int State
        {
            get => _state;
            set
            {
                Previous = _state;
                _state = value;
            }
        }

        private int _state;
        public int Previous = 0;
        public readonly int X;
        public readonly int Y;
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
