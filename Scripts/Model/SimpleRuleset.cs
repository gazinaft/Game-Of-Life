namespace GameOfLife.Scripts.Model
{
    public class SimpleRuleset: IRuleset
    {
        public void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            var next = new int[columns, rows];

            for (int x = 1; x < columns - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    next[x, y] = EvalCell(ref cells, x, y);
                }
            }
            
            cells = next;
        }

        public int EvalCell(ref int[,] board, int x, int y)
        {
            int neighbors = 0;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    neighbors += board[x+i, y+j];
                }
            }
            neighbors -= board[x,y];
            
            if (board[x, y] == 1 && neighbors < 2) return 0;
            if (board[x, y] == 1 && neighbors > 3) return 0;
            if (board[x, y] == 0 && neighbors == 3) return 1;
            return board[x, y];
        }
        
    }
}
