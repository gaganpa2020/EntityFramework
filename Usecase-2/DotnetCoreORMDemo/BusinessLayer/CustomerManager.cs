using DotnetCoreORMDemo.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreORMDemo.BusinessLayer
{
   public static class CustomerManager
    {
        public static void ListAllCustomerIDs()
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF ALL CUSTOMER IDS");
            Console.WriteLine("============================");
            Console.WriteLine();

            // Get the IDs from the database
            List<string> customerIDs = CustomerRepository.GetCustomerIDs();

            string customerIDsInOneLine = String.Empty;

            // Put all IDs into a single string
            foreach (string customerID in customerIDs)
            {
                customerIDsInOneLine = customerIDsInOneLine + customerID + ",";
            }

            // Remove the last "," delimiter
            customerIDsInOneLine = customerIDsInOneLine.TrimEnd(',');

            Console.WriteLine(customerIDsInOneLine);
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
