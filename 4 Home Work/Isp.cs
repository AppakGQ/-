using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}

public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }
}

public class ScannerPrinter : IPrinter, IScanner
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        AllInOnePrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("Document 1");
        allInOnePrinter.Scan("Document 2");
        allInOnePrinter.Fax("Document 3");

        BasicPrinter basicPrinter = new BasicPrinter();
        basicPrinter.Print("Document 4");

        ScannerPrinter scannerPrinter = new ScannerPrinter();
        scannerPrinter.Print("Document 5");
        scannerPrinter.Scan("Document 6");
    }
}
