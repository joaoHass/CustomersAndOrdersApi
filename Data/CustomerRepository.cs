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

        public async Task<ICollection<Customer>> GetAll() => await _context.Customers.AsNoTracking().ToListAsync();

        public async Task<Customer?> Get(int id) => await _context.Customers.FindAsync(id);
    }
}