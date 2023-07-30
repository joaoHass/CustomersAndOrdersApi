using Application.Authentication;
using Domain.Customers;
using Domain.Orders;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSecurity> Users_Security { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=customers_and_orders;Username=customers&orders_app;Password=customers");
        }
    }
}
