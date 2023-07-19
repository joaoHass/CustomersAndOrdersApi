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
        public IActionResult CreateNewCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            Customer c1 = new Customer();
            c1.Name = customerCreateDto.Name;
            c1.CPF = customerCreateDto.CPF;
            c1.Adress = customerCreateDto.Address;

            _repository.Add(c1);

            return Ok($"Customer with Id {c1.Id} was created");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCostumer(int id)
        {
            return Ok("Not implemented");
        }
    }
}