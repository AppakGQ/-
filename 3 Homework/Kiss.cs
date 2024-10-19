using System;

public class NumberProcessor
{
    public void ProcessNumbers(int[] numbers)
    {
        
        if (numbers == null || numbers.Length == 0)
        {
            return; 
        }

        foreach (var number in numbers)
        {
            if (number > 0)
            {
                Console.WriteLine(number);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        NumberProcessor processor = new NumberProcessor();

        
        int[] numbers = { -1, 2, 3, -4, 5, 0 };
        processor.ProcessNumbers(numbers);
    }
}
