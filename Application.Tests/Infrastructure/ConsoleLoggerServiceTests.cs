using Infrastructure.Logging;
using System;
using System.IO;
using Xunit;

namespace Application.Tests.Infrastructure;

public class ConsoleLoggerServiceTests
{
    [Fact]
    public void Log_ShouldWriteToConsole()
    {
        var logger = new ConsoleLoggerService();
        var originalConsoleOut = Console.Out;
        try
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            logger.Log("Hello");
            Assert.Contains("Hello", sw.ToString());
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
        }
    }
}
