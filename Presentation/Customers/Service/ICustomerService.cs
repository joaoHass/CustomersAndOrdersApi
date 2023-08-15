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
        public Task<Customer?> Get(int id);
        public Task<ICollection<Customer>> GetAll();

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <exception cref="ArgumentNullException">Thrown if the passed id does not point to any Customer</exception>
        public void Update(int id, CustomerUpdateDto dto);

    }
}
