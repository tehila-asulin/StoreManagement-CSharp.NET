using System;
using BlApi;
using BO;

namespace BlTest
{
    class Program
    {
        static readonly IBl s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            // Initialize the DAL
            //DalApi.Factory.Initialize();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("select an option:");
                Console.WriteLine("1. start New Order");
                Console.WriteLine("2. exit");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    StartNewOrder();
                }
                else if (choice == "2")
                {
                    exit = true;
                }
            }
        }

        static void StartNewOrder()
        {
            Console.WriteLine("enter user id or 0 for unregistered:");
            int userId;
            int.TryParse(Console.ReadLine(), out userId);

            var order = new Order { ProductsInOrder = new List<ProductInOrder>() }; 

            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("enter Product ID:");
                int productId;
                int.TryParse(Console.ReadLine(), out productId);

                Console.WriteLine("enter Quantity:");
                int quantity;
                int.TryParse(Console.ReadLine(), out quantity);

                try
                {
                    var sales = s_bl.order.AddProductToOrder(order, productId, quantity);
                    Console.WriteLine($"product added: {string.Join(", ", sales.Select(s => s.SaleId))}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"total price: {order.TotalPrice}");
                Console.WriteLine("add another product? (y/n)");
               
                if (Console.ReadLine().ToLower() == "n")
                {
                    s_bl.order.DoOrder(order);
                    continueAdding = false;
                }
  
            }

            Console.WriteLine("order completed. Start a new order? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                StartNewOrder();
            }
           
        }
    }
}
