using System;

public class NumberPrinter
{
    public void PrintPositiveNumbers(int[] numbers)
    {
        if (numbers == null) return;

        Array.Sort(numbers);

        foreach (var number in numbers)
        {
            if (number > 0)
            {
                Console.WriteLine(number);
            }
        }
    }
}

public class Calculator
{
    public int Divide(int a, int b)
    {
        if (b == 0) return 0;
        return a / b;
    }
}

public class Program
{
    public static void Main()
    {
        NumberPrinter printer = new NumberPrinter();
        int[] numbers = { -1, 3, 0, 5, -2, 1 };
        printer.PrintPositiveNumbers(numbers);

        Calculator calculator = new Calculator();
        Console.WriteLine(calculator.Divide(10, 2));
        Console.WriteLine(calculator.Divide(10, 0));
    }
}
