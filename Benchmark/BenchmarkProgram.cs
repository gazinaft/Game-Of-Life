using System;
using System.Diagnostics;
using System.Threading;
using GameOfLife.Scripts.Model;
using NUnit.Framework;

namespace Benchmark
{
    [TestFixture]
    class BenchmarkProgram
    {
        [Test]
        public static void Benchmark()
        {
            // var dt1 = 0;
            // var dt2 = 0;
            // ThreadPool.GetAvailableThreads(out dt1, out dt2);
            //
            // var threadnums = new int[] {  2, 4, 8, 12, 16, dt2 };
            // var tasknums = new int[] { 2, 4, 8, 12, 16, 20 };

            // {
            //     foreach (int threadnum in threadnums)
            //     {
            //         foreach (var tasknum in tasknums)
            //         {
            //             var seq1 = BenchmarkGoL(4, 100, siz,
            //                 new ParallelThreadPoolRuleset() { Parallelism = threadnum, Tasks = tasknum });
            //             Console.WriteLine(seq1 + " at tasks " + tasknum + " and threads " + threadnum);
            //         }
            //     }
            // }
            var sizes = new int[] { 100, 500, 1000 };
            foreach (int siz in sizes)
            {
                var seq = BenchmarkGoL(4, 100, siz, new SequentialRuleset());
                var parFor = BenchmarkGoL(4, 100, siz, new OuterFor());
                var parPool = BenchmarkGoL(4, 100, siz,
                    new ParallelThreadPoolRuleset() { Tasks = 8, Parallelism = 2 });
                var parThread = BenchmarkGoL(4, 100, siz, new ParallelThreadRuleset() { Parallelism = 4 });
                Console.WriteLine("For Speedup is " + (seq / (double)parFor));
                Console.WriteLine("Pool Speedup is " + (seq / (double)parPool));
                Console.WriteLine("Thread Speedup is " + (seq / (double)parThread));
            }
        }

        private static long BenchmarkGoL(int iterations, int generations, int size, IRuleset rules)
        {
            GC.Collect();
            var ca = new CA(new int[size, size], rules);
            // init launch
            ca.MakeNSteps(generations);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                ca.MakeNSteps(generations);
            }
            sw.Stop();
            Console.WriteLine($"Time for size {size} and {generations} generations with {rules.GetType()} " + (sw.ElapsedMilliseconds / iterations) + " ms");
            return sw.ElapsedMilliseconds/iterations;
        }

    }

}