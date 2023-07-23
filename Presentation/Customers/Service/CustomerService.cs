
using Domain.Customers;
using Domain.Interfaces;
using Presentation.Customers.Dtos;

namespace Presentation.Customers.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _repository = customerRepository;
        }

        public void Add(CustomerCreateDto entity)
        {
            if (entity == null) throw new ArgumentNullException();

            Customer newCustomer = new()
            {
                Name = entity.Name,
                CPF = entity.CPF,
                Adress = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                BirthDate = entity.BirthDate,
                Orders = entity.Orders
            };

            _repository.Add(newCustomer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Customer? Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
