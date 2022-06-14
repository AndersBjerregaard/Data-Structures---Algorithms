using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkStrings
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private ILogger<T> _logger;

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message);
            }
        }

        public void LogInformation<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0);
            }
        }

        public void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1);
            }
        }

        public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1, arg2);
            }
        }

        public void LogInformation<T0, T1, T2, T3>(string message, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1, arg2, arg3);
            }
        }
    }

    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);

        void LogInformation<T0>(string message, T0 arg0);

        void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);

        void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        void LogInformation<T0, T1, T2, T3>(string message, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
    }
}
