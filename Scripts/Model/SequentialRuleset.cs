namespace GameOfLife.Scripts.Model
{
    public class SequentialRuleset: ClassicRuleset
    {
        public override void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            // створення нового поля з клітинками
            var next = new int[columns, rows];

            // обчислення кожної нової клітинки
            for (int x = 1; x < columns - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    next[x, y] = EvalCell(cells, x, y);
                }
            }
            // заміна старого поля новим
            cells = next;
        }

    }
}
