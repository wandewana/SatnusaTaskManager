using Domain.Services;
using System;

namespace Infrastructure.Logging;

public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
