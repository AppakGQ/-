
using System;
using System.Collections.Generic;

namespace OnlineBankingSystem
{
   
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

 
    public class Transaction
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } 
    }

   
    public class AuthService
    {
        public bool Authenticate(string username, string password)
        {
            
            return true;
        }

        public string GenerateToken(string userId)
        {
            return Guid.NewGuid().ToString();
        }
    }

    public class PaymentGateway
    {
        public bool ProcessPayment(string fromAccount, string toAccount, decimal amount)
        {
            return true;
        }
    }

    public class NotificationService
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"Email sent to {email}: {message}");
        }

        public void SendSms(string phone, string message)
        {
            Console.WriteLine($"SMS sent to {phone}: {message}");
        }
    }

    public class OnlineBankingSystem
    {
        private AuthService _authService = new AuthService();
        private PaymentGateway _paymentGateway = new PaymentGateway();
        private NotificationService _notificationService = new NotificationService();

        public void PerformTransaction(string fromAccount, string toAccount, decimal amount)
        {
            if (_paymentGateway.ProcessPayment(fromAccount, toAccount, amount))
            {
                Console.WriteLine("Transaction successful!");
                _notificationService.SendSms("123-456-7890", "Your transaction was successful.");
            }
            else
            {
                Console.WriteLine("Transaction failed.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OnlineBankingSystem bankingSystem = new OnlineBankingSystem();
            bankingSystem.PerformTransaction("ACC123", "ACC456", 500);
        }
    }
}
