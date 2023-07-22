using Domain.Customers;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Delete(int id)
        {
            Customer? customerToDelete = _context.Customers.Find(id);

            if (customerToDelete is null)
                throw new ArgumentNullException($"A customer with the id {id} was not found.");

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }

        public ICollection<Customer> GetAll() => _context.Customers.AsNoTracking().ToList();

        public Customer? Get(int id) => _context.Customers.Find(id);
    }
}