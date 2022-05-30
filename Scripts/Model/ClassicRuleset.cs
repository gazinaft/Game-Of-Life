namespace GameOfLife.Scripts.Model
{
    public abstract class ClassicRuleset : IRuleset
    {
        public abstract void Eval(ref int[,] cells);

        public int EvalCell(int[,] board, int x, int y)
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