using System;
using System.Diagnostics;
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
            var seq = BenchmarkGoL(4, 100, 1000, new SequentialRuleset());
            var parFor = BenchmarkGoL(4, 100, 1000, new ParallelForRuleset());
            var parPool = BenchmarkGoL(4, 100, 1000, new ParallelThreadPoolRuleset() {Tasks = 8});
            var parThread = BenchmarkGoL(4, 100, 1000, new ParallelThreadRuleset() { Parallelism = 2});
            Console.WriteLine("For Speedup is " + (seq/(double)parFor));
            Console.WriteLine("Pool Speedup is " + (seq/(double)parPool));
            Console.WriteLine("Thread Speedup is " + (seq/(double)parThread));
            
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
            return sw.ElapsedMilliseconds;
        }

    }

}