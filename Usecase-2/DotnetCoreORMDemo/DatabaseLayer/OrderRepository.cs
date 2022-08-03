using DotnetCoreORMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreORMDemo.DatabaseLayer
{
    public class OrderRepository
    {
        //This method is used to get the order using customer id
        public static List<Order> GetOrdersByCustomerID(string customerID)
        {
            List<Order> orders = new List<Order>();

            using (CustomerManagementContext context = new CustomerManagementContext())
            {
                orders = (from p in context.Orders
                          where p.customerID.Equals(customerID.Trim())
                          select p).ToList();
            }

            return orders;
        }
    }
}
