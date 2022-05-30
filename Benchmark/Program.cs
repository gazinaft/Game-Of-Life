using System;
using System.Diagnostics;
using GameOfLife.Scripts.Model;

namespace Benchmark
{
    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkGoL(4, 100, 1000, new SequentialRuleset());
            BenchmarkGoL(4, 100, 1000, new ParallelForRuleset());
        }

        private static void BenchmarkGoL(int iterations, int generations, int size, IRuleset rules)
        {
            GC.Collect();
            var ca = new CA(new int[size, size], rules);
            ca.MakeNSteps(generations);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                ca.MakeNSteps(generations);
            }
            sw.Stop();
            Console.WriteLine($"Time for size {size} and {generations} generations with {rules.GetType()} " + (sw.ElapsedMilliseconds / iterations) + " ms");
        }

    }

}
