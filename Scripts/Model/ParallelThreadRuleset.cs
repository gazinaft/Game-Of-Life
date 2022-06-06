using System;
using System.Threading;

namespace GameOfLife.Scripts.Model
{
    public class ParallelThreadRuleset : ClassicRuleset
    {
        public int Parallelism { get; set; }

        public ParallelThreadRuleset()
        {
            Parallelism = 8;
        }
        
        public override void Eval(ref int[,] cells)
        {
            var columns = cells.GetLength(0);
            var rows = cells.GetLength(1);

            var next = new int[columns, rows];
            Partition(next, cells, Parallelism);
            
            cells = next;
        }
        

        private void Partition(int[,] res, int[,] src, int threadNumber)
        {
            var ps = Math.Min(res.GetLength(0), threadNumber);
            int n = res.GetLength(0) / ps;
            var tasks = new Thread[ps];
            
            for (int i = 0; i < ps; ++i) {
                var start = i*n;
                var partSize = i == ps - 1 ? Math.Max(n, res.GetLength(0) - i * n) : n;
                var t = new Thread(() => CalcPart(res, src, start, start + partSize));
                t.Start();
                tasks[i] = t;
            }

            foreach (Thread thread in tasks)
            {
                thread.Join();
            }
        }

        private void CalcPart(int[,] res, int[,] src, int start, int end)
        {
            var width = res.GetLength(1);
            var s = start == 0 ? 1 : start;
            var e = end == res.GetLength(0) ? end - 1 : end;
            for (int i = s; i < e; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    res[i, j] = EvalCell(src, i, j);
                }
            }
        } 
    }
    
}