using DotnetCoreORMDemo.Helper;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreORMDemo.Models
{
    public class CustomerManagementContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WritableRow> WritableRows { get; set; }

        public CustomerManagementContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStringProvider.Get());
            }
        }       
    }
}
