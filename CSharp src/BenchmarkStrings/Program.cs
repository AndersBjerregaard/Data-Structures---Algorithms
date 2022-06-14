using BenchmarkDotNet.Running;
using System;

namespace BenchmarkStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<LoggingExamplesBenchmarks>();
        }
    }
}
