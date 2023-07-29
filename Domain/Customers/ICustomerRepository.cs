using Domain.Interfaces;

namespace Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICollection<Customer> GetCustomers();
    }
}
