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

            return Ok(_repository.GetCustomers());
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