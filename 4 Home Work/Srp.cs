using System;

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Order(string productName, int quantity, double price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public double CalculateTotalPrice()
    {
        return Quantity * Price * 0.9;
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        Console.WriteLine("Payment processed using: " + paymentDetails);
    }
}

public class EmailService
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine("Confirmation email sent to: " + email);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Order order = new Order("Laptop", 2, 1000.0);
        double totalPrice = order.CalculateTotalPrice();
        Console.WriteLine("Total price after discount: " + totalPrice);

        PaymentProcessor paymentProcessor = new PaymentProcessor();
        paymentProcessor.ProcessPayment("Credit Card");

        EmailService emailService = new EmailService();
        emailService.SendConfirmationEmail("customer@example.com");
    }
}
