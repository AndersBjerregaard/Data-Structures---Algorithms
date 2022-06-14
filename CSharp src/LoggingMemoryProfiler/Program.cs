using Microsoft.Extensions.Logging;
using System;

namespace LoggingMemoryProfiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
            });

            ILogger logger = new Logger<Program>(loggerFactory);

            Random rng = new Random();

            // Showcase boxing of value types
            for (int i = 0; i < 69000000; i++)
            {
                logger.LogInformation("Random number {RandomNumber}", rng.Next());
            }

            // Showcase immutable reference type (strings)
            //for (int i = 0; i < 69000000; i++)
            //{
            //    logger.LogInformation($"Random number {rng.Next()}");
            //}
        }
    }
}
