using Domain.Customers;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CustomerContext : DbContext, IRepository<Customer>
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=customers_and_orders;Username=customers&orders_app;Password=customers");
        }

        public void Add(Customer customer) => Customers.Add(customer);

        public void Delete(Customer entity) => Customers.Remove(entity);

        public void Update(Customer entity) => Customers.Update(entity);
    }
}