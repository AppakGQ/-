using System;

public static class Config
{
    public static string ConnectionString { get; } =
        "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
}

public class DatabaseService
{
    public void Connect()
    {
        string connectionString = Config.ConnectionString;
        Console.WriteLine($"Connecting to database with: {connectionString}");
    }
}

public class LoggingService
{
    public void Log(string message)
    {
        string connectionString = Config.ConnectionString;
        Console.WriteLine($"Logging message to database with: {connectionString}");
    }
}

public class Program
{
    public static void Main()
    {
        DatabaseService dbService = new DatabaseService();
        dbService.Connect();

        
        LoggingService logService = new LoggingService();
        logService.Log("Application started");
    }
}
