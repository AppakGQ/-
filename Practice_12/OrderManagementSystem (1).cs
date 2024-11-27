
using System;
using System.Collections.Generic;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AddProduct(new Product { ID = 1, Name = "Laptop", Price = 1200 });
            cart.AddProduct(new Product { ID = 2, Name = "Mouse", Price = 25 });

            var order = new Order
            {
                CustomerName = "John Doe",
                Address = "123 Main St",
                Cart = cart
            };

            Console.WriteLine("Order created. Total: " + order.Cart.GetTotal());

            var payment = new Payment { Amount = 1500 };
            if (order.Pay(payment))
            {
                Console.WriteLine("Payment successful.");
                order.ConfirmOrder();
                var processor = new OrderProcessor();
                processor.ProcessOrder(order);
            }
            else
            {
                Console.WriteLine("Payment failed.");
            }
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Cart
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Added {product.Name} to cart.");
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }
    }

    public class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public Cart Cart { get; set; }
        public bool IsPaid { get; private set; }
        public bool IsConfirmed { get; private set; }

        public bool Pay(Payment payment)
        {
            if (payment.Amount >= Cart.GetTotal())
            {
                IsPaid = true;
                return true;
            }
            return false;
        }

        public void ConfirmOrder()
        {
            if (IsPaid)
            {
                IsConfirmed = true;
                Console.WriteLine("Order confirmed.");
            }
            else
            {
                Console.WriteLine("Order cannot be confirmed. Payment not completed.");
            }
        }
    }

    public class Payment
    {
        public double Amount { get; set; }
    }

    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            if (order.IsConfirmed)
            {
                Console.WriteLine("Order is being processed.");
                Console.WriteLine("Sending order to warehouse.");
                Console.WriteLine("Order dispatched for delivery.");
            }
            else
            {
                Console.WriteLine("Order cannot be processed. It is not confirmed.");
            }
        }
    }
}
