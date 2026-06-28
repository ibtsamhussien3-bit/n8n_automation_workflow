using System;
using System.Collections.Generic;

namespace OrderAutomation
{
    // Model
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }
        public bool IsComplete { get; set; }
    }

    // Service
    public class OrderProcessor
    {
        private List<Order> _orders = new List<Order>();

        // Add new order
        public void AddOrder(Order order)
        {
            _orders.Add(order);
            Console.WriteLine($"Order {order.Id} added for {order.CustomerName}");
        }

        // Get all complete orders
        public List<Order> GetCompleteOrders()
        {
            return _orders.FindAll(o => o.IsComplete);
        }

        // Calculate total revenue
        public double GetTotalRevenue()
        {
            double total = 0;
            foreach (var order in _orders)
            {
                if (order.IsComplete)
                    total += order.TotalAmount;
            }
            return total;
        }

        // Mark order as complete
        public void CompleteOrder(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order != null)
            {
                order.IsComplete = true;
                Console.WriteLine($"Order {orderId} marked as complete.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var processor = new OrderProcessor();

            processor.AddOrder(new Order { Id = 1, CustomerName = "Alice", TotalAmount = 150.0, IsComplete = false });
            processor.AddOrder(new Order { Id = 2, CustomerName = "Bob", TotalAmount = 200.0, IsComplete = false });

            processor.CompleteOrder(1);

            Console.WriteLine($"Total Revenue: ${processor.GetTotalRevenue()}");
            Console.WriteLine($"Complete Orders: {processor.GetCompleteOrders().Count}");
        }
    }
}
