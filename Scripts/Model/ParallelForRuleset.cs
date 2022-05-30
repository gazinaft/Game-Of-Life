using System.Threading.Tasks;

namespace GameOfLife.Scripts.Model
{
    public class ParallelForRuleset: ClassicRuleset
    {
        public override void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            var next = new int[columns, rows];

            var ints = cells;
            Parallel.For(1, columns - 1, x =>
            {
                Parallel.For(1, rows - 1, y =>
                {
                    next[x, y] = EvalCell(ints, x, y);
                });
            });
            
            cells = next;
        }
    }
}