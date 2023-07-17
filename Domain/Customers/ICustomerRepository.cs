using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICollection<Customer> GetCustomers();
    }
}
