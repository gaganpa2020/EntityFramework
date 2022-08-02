using System;
using System.Collections.Generic;

namespace MyCSharpDotNet.AdoDotNetApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("MAIN MENU");
                Console.WriteLine("=========");
                Console.WriteLine();

                Console.WriteLine(
                    "Your options:");
                Console.WriteLine(
                    "----------------------------------------------------------");
                Console.WriteLine(
                    "[1] List all customer IDs");
                Console.WriteLine(
                    "[2] List orders by a specific CustomerID");
                Console.WriteLine(
                    "[3] Create your own entry in the WritableRows table");
                Console.WriteLine(
                    "[4] Show the most recent entry in the WritableRows table");
                Console.WriteLine(
                    "[0] Exit the application");
                Console.WriteLine(
                    "----------------------------------------------------------");

                Console.Write("Your selection: ");

                int? option = null;

                // Repeat until an acceptable key is pressed
                while (!option.HasValue)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    if ("12340".Contains(consoleKeyInfo.KeyChar.ToString()))
                        option = Int32.Parse(consoleKeyInfo.KeyChar.ToString());
                }

                Console.Write(option.Value);

                // Perform action based on the selection
                if (option.Value == 1)
                    ListAllCustomerIDs();
                else if (option.Value == 2)
                    ListOrdersByCustomerID();
                else if (option.Value == 3)
                    CreateNewRow();
                else if (option.Value == 4)
                    ShowMostRecentRow();
                else if (option.Value == 0)
                    break;
            }
        }

        private static void ListAllCustomerIDs()
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF ALL CUSTOMER IDS");
            Console.WriteLine("============================");
            Console.WriteLine();

            // Get the IDs from the database
            List<string> customerIDs = Customer.GetCustomerIDs();

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

        private static void ListOrdersByCustomerID()
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF ORDERS BY CUSTOMER ID");
            Console.WriteLine("=================================");
            Console.WriteLine();

            Console.WriteLine("Enter the CustomerID (eg.: GODOS, SUPRD, ...):");
            string customerID = Console.ReadLine();

            Console.Clear();

            // Get the orders from the database
            List<Order> orders = Order.GetOrdersByCustomerID(customerID);

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

        private static void CreateNewRow()
        {
            Console.Clear();

            Console.WriteLine("CREATE NEW ROW");
            Console.WriteLine("==============");
            Console.WriteLine();

            Console.WriteLine("Enter the your text:");
            string text = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Enter the your nickname:");
            string nickname = Console.ReadLine();

            Console.Clear();

            // Create new WritableRow object and save it to the database
            WritableRow writableRow = new WritableRow(text, nickname);
            writableRow.Save();

            Console.Clear();

            Console.WriteLine("CREATE NEW ROW");
            Console.WriteLine("==============");
            Console.WriteLine();

            Console.WriteLine("The following row has been created:");
            Console.WriteLine();

            Console.WriteLine(writableRow);
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

        private static void ShowMostRecentRow()
        {
            Console.Clear();

            // Get the most recent WritableRow from the database
            WritableRow writableRow = WritableRow.GetMostRecent();

            Console.Clear();

            Console.WriteLine("MOST RECENT ROW");
            Console.WriteLine("===============");
            Console.WriteLine();

            Console.WriteLine(writableRow);
            Console.WriteLine();

            Console.WriteLine(
                "Your options:");
            Console.WriteLine(
                "----------------------------------------------------------");
            Console.WriteLine(
                "[9] Delete the row");
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
                if ("90".Contains(consoleKeyInfo.KeyChar.ToString()))
                    option = Int32.Parse(consoleKeyInfo.KeyChar.ToString());
            }

            Console.Write(option.Value);

            // If requested, delete the WritableRow
            if (option.Value == 9)
            {
                Console.Clear();

                // Perform the delete
                writableRow.Delete();

                Console.WriteLine("MOST RECENT ROW");
                Console.WriteLine("===============");
                Console.WriteLine();

                Console.WriteLine("The most recent row has been deleted");
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

                int? option2 = null;

                // Repeat until an acceptable key is pressed
                while (!option2.HasValue)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    if ("90".Contains(consoleKeyInfo.KeyChar.ToString()))
                        option2 = Int32.Parse(consoleKeyInfo.KeyChar.ToString());
                }

                Console.Write(option2.Value);
            }
        }
    }
}
