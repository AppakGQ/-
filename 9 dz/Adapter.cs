using System;

public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing payment of {amount:C2} via PayPal.");
    }
}

public class StripePaymentService
{
    public void MakeTransaction(double totalAmount)
    {
        Console.WriteLine($"Processing payment of {totalAmount:C2} via Stripe.");
    }
}

public class StripePaymentAdapter : IPaymentProcessor
{
    private StripePaymentService _stripeService;
    public StripePaymentAdapter(StripePaymentService stripeService)
    {
        _stripeService = stripeService;
    }
    public void ProcessPayment(double amount)
    {
        _stripeService.MakeTransaction(amount);
    }
}

public class SquarePaymentService
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Processing payment of {amount:C2} via Square.");
    }
}

public class SquarePaymentAdapter : IPaymentProcessor
{
    private SquarePaymentService _squareService;
    public SquarePaymentAdapter(SquarePaymentService squareService)
    {
        _squareService = squareService;
    }
    public void ProcessPayment(double amount)
    {
        _squareService.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
        paypalProcessor.ProcessPayment(50.0);

        IPaymentProcessor stripeProcessor = new StripePaymentAdapter(new StripePaymentService());
        stripeProcessor.ProcessPayment(75.0);

        IPaymentProcessor squareProcessor = new SquarePaymentAdapter(new SquarePaymentService());
        squareProcessor.ProcessPayment(100.0);
    }
}