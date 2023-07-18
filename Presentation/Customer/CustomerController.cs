using Microsoft.AspNetCore.Mvc;
using Domain.Customers;
using Domain.Interfaces;

namespace Presentation
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            Customer c1 = new Customer();
            c1.Name = "John";
            c1.Id = 1;
            Customer c2 = new Customer();
            c2.Name = "Doe";
            c2.Id = 2;

            return Ok(new Customer[] { c1, c2 }) ;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCustomer([FromBody] string temporaryParameter)
        {
            return Ok("Not Implemented");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCostumer(int id)
        {
            return Ok("Not implemented");
        }
    }
}