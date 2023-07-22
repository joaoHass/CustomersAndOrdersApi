using Domain.Customers;
using Domain.Interfaces;
using Presentation.Customers.Dtos;

namespace Presentation.Customers.Service
{
    public interface ICustomerService 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Thrown if any informed field in the DTO is invalid</exception>
        void Add(CustomerCreateDto entity);
        public void Delete(int id);
        public Customer? Get(int id);
        public ICollection<Customer> GetAll();
        public void Update(Customer entity);

    }
}
