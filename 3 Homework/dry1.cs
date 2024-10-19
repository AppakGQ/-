using System;

public class Logger
{
    public void Log(string message, string level)
    {
        Console.WriteLine($"{level.ToUpper()}: {message}");
    }

    public void LogError(string message) => Log(message, "error");
    public void LogWarning(string message) => Log(message, "warning");
    public void LogInfo(string message) => Log(message, "info");
}

public class Program
{
    public static void Main()
    {
        Logger logger = new Logger();

        logger.LogError("File not found");
        logger.LogWarning("Low disk space");
        logger.LogInfo("Operation completed");
    }
}
