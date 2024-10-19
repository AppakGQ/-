using System;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    public void SaveToDatabase()
    {
        // Код для сохранения пользователя в базу данных
    }
}

public class FileReader
{
    public string ReadFile(string filePath)
    {
        
        return "file content";
    }
}

public class ReportGenerator
{
    public void GenerateReport()
    {
        // Генерация отчета
    }
}

public class Program
{
    public static void Main()
    {
        User user = new User { Name = "John Doe", Email = "john@example.com" };
        user.SaveToDatabase();

        FileReader fileReader = new FileReader();
        Console.WriteLine(fileReader.ReadFile("example.txt"));

        ReportGenerator reportGenerator = new ReportGenerator();
        reportGenerator.GenerateReport();
    }
}
