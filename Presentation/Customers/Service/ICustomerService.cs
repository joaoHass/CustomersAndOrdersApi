using Domain.Customers;
using Domain.Interfaces;
using Presentation.Customers.Dtos;

namespace Presentation.Customers.Service
{
    public interface ICustomerService 
    {
        void Add(CustomerCreateDto entity);
        public void Delete(int id);
        public Customer? Get(int id);
        public ICollection<Customer> GetAll();
        public void Update(Customer entity);

    }
}
