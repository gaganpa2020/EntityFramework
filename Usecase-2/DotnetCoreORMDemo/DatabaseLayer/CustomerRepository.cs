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
                customerIDs = context.Customers.Select(x => x.CustomerID).ToList();
            }

            return customerIDs;
        }
    }
}
