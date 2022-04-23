namespace GameOfLife.Scripts.Model
{
    public class SimpleRuleset: IRuleset
    {
        public void Eval(CA board)
        {
            for (var x = 1; x < board.Columns - 1; x++)
            {
                for (var y = 1; y < board.Rows - 1; y++)
                {
                    var neighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            neighbors += board.Cells[x + i, y + j].Previous;
                        }
                    }

                    neighbors -= board.Cells[x, y].Previous;

                    if (board.Cells[x, y].State == 1 && neighbors < 2) board.Cells[x, y].State = 0;
                    else if (board.Cells[x, y].State == 1 && neighbors > 3) board.Cells[x, y].State = 0;
                    else if (board.Cells[x, y].State == 0 && neighbors == 3) board.Cells[x, y].State = 1;
                }
            }
        }
        
    }
}
