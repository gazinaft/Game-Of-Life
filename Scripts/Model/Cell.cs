namespace GameOfLife.Scripts.Model
{
    public class Cell
    {
        public int State = 0;
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
