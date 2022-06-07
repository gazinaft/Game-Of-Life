using System.Threading.Tasks;

namespace GameOfLife.Scripts.Model
{
    public class InnerFor: ClassicRuleset
    {
        public override void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            var next = new int[columns, rows];

            var ints = cells;
            for (int x = 1; x < columns - 1; x++)
            {
                int a = x;
                Parallel.For(1, rows - 1, y =>    
                {
                    next[a, y] = EvalCell(ints, a, y);
                });
            }
            
            cells = next;
        }
    }
}