using DotnetCoreORMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreORMDemo.DatabaseLayer
{
    public static class CustomerRepository
    {
        public static List<string> GetCustomerIDs()
        {
            List<string> customerIDs = new List<string>();

            using (CustomerManagementContext context = new CustomerManagementContext())
            {
                //customerIDs = context.Customers.Select(x => x.CustomerID).ToList();

                customerIDs = (from p in context.Customers
                               select p.CustomerID).ToList(); // Linq query
            }

            return customerIDs;
        }

        /*
            public static List<Order> GetOrdersByCustomerID(string customerID)
            {
                List<Order> orders = new List<Order>();
                using (CustomerManagementContext context = new CustomerManagementContext())
                {
                    orders = context.Orders.Select(x => x.CustomerID).ToList().;
                }
                return orders;
            }
        */
    }
}
