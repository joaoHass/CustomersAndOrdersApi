
using Domain.Customers;
using Domain.Interfaces;
using Presentation.Customers.Dtos;

namespace Presentation.Customers.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IRepository<Customer> customerRepository, ILogger<CustomerService> logger)
        {
            _repository = customerRepository;
            _logger = logger;
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
            return _repository.Get(id);
        }

        public ICollection<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(int id, CustomerUpdateDto dto)
        {
            Customer? customerToUpdate = Get(id);

            if (customerToUpdate == null) throw new ArgumentNullException($"A customer with the id {id} does not exist");

            if (dto.Name != null)
                customerToUpdate.Name = dto.Name;

            if (dto.CPF != null)
                customerToUpdate.CPF = dto.CPF;

            if (dto.Address != null)
                customerToUpdate.Adress = dto.Address;

            if (dto.PhoneNumber != null)
                customerToUpdate.PhoneNumber = dto.PhoneNumber;

            if (dto.BirthDate != null)
                customerToUpdate.BirthDate = dto.BirthDate;

            _repository.Update(customerToUpdate);
        }
    }
}
