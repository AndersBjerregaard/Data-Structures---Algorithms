using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkStrings
{
    public class LoggingExamples
    {
        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
        });

        public readonly ILogger<LoggingExamples> _logger;

        public readonly ILoggerAdapter<LoggingExamples> _loggerAdapter;

        public LoggingExamples()
        {
            _logger = new Logger<LoggingExamples>(_loggerFactory);
            _loggerAdapter = new LoggerAdapter<LoggingExamples>(_logger);
        }
    }
}
