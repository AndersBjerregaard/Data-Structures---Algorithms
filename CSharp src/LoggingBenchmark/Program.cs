using BenchmarkDotNet.Running;
using System;

namespace LoggingBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarkie>();
        }
    }
}
