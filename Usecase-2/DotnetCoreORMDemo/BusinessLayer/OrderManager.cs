using DotnetCoreORMDemo.DatabaseLayer;
using DotnetCoreORMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreORMDemo.BusinessLayer
{
    public class OrderManager
    {
        public static void ListOrdersByCustomerID()
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF ORDERS BY CUSTOMER ID");
            Console.WriteLine("=================================");
            Console.WriteLine();

            Console.WriteLine("Enter the CustomerID (eg.: GODOS, SUPRD, ...):");
            string customerID = Console.ReadLine();

            Console.Clear();

            // Get the orders from the database
            List<Order> orders = OrderRepository.GetOrdersByCustomerID(customerID);

            Console.Clear();

            Console.WriteLine("THE LIST OF ORDERS BY CUSTOMER ID");
            Console.WriteLine("=================================");
            Console.WriteLine();

            foreach (Order order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(
                "Your options:");
            Console.WriteLine(
                "----------------------------------------------------------");
            Console.WriteLine(
                "[0] Return to the main menu");
            Console.WriteLine(
                "----------------------------------------------------------");

            Console.Write("Your selection: ");

            int? option = null;

            // Repeat until an acceptable key is pressed
            while (!option.HasValue)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if ("0".Contains(consoleKeyInfo.KeyChar.ToString()))
                    option = Int32.Parse(consoleKeyInfo.KeyChar.ToString());
            }

            Console.Write(option.Value);
        }

    }
}
