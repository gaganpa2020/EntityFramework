using DotnetCoreORMDemo.BusinessLayer;
using System;

namespace DotnetCoreORMDemo
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

                //// Perform action based on the selection
                if (option.Value == 1)
                    CustomerManager.ListAllCustomerIDs();
                //else if (option.Value == 2)
                //    ListOrdersByCustomerID();
                //else if (option.Value == 3)
                //    CreateNewRow();
                //else if (option.Value == 4)
                //    ShowMostRecentRow();
                else if (option.Value == 0)
                    break;
            }
        }
    }
}
