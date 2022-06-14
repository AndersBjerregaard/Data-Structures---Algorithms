using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingBenchmark
{
    [MemoryDiagnoser]
    [OrderProvider(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarkie
    {
        private const string LogMessageWithParameters =
            "This is a log message with parameters {0}, {1} and {2}";
        private const string LogMessage = "This is a log message";

        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Warning);
        });

        private readonly ILogger<Benchmarkie> _logger;

        public Benchmarkie()
        {
            _logger = new Logger<Benchmarkie>(_loggerFactory);
        }

        [Benchmark]
        public void Log_WithoutIf()
        {
            _logger.LogInformation(LogMessage);
        }

        [Benchmark]
        public void Log_WithIf()
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(LogMessage);
            }
        }
    }
}
