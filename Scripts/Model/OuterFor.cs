using System.Threading.Tasks;

namespace GameOfLife.Scripts.Model
{
    public class OuterFor: ClassicRuleset
    {
        public override void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            var next = new int[columns, rows];

            var ints = cells;
            Parallel.For(1, columns - 1, x =>
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    next[x, y] = EvalCell(ints, x, y);
                }
            });
            
            cells = next;
        }
    }
}