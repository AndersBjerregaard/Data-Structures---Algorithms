using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkStrings
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoggingExamplesBenchmarks
    {
        private const string LogMessageWithParameters =
            "This is a log message with parameters {0} and {1}";
        private const string LogMessage = "This is a log message";

        private static LoggingExamples _loggingExamples = new LoggingExamples();

        [Benchmark]
        public void Log_WithoutIf()
        {
            _loggingExamples._logger.LogInformation(LogMessage);
        }

        [Benchmark]
        public void Log_WithIf()
        {
            if (_loggingExamples._logger.IsEnabled(LogLevel.Information))
            {
                _loggingExamples._logger.LogInformation(LogMessage);
            }
        }

        [Benchmark]
        public void Log_WithoutIf_WithParams()
        {
            _loggingExamples._logger.LogInformation(LogMessageWithParameters, 69, 420);
        }

        [Benchmark]
        public void Log_WithIf_WithParams()
        {
            if (_loggingExamples._logger.IsEnabled(LogLevel.Information))
            {
                _loggingExamples._logger.LogInformation(LogMessageWithParameters, 69, 420);
            }
        }

        [Benchmark]
        public void LogAdapter_WithoutIf_WithParams()
        {
            _loggingExamples._loggerAdapter.LogInformation(LogMessageWithParameters, 69, 420);
        }
    }
}
