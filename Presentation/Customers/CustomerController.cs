using Microsoft.AspNetCore.Mvc;
using Domain.Customers;
using Presentation.Customers.Dtos;
using System.Net.Mime;
using Presentation.Customers.Service;

namespace Presentation
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        [Route("")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult CreateNewCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            try
            {
                _service.Add(customerCreateDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Customer was created successfully");
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCostumer(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"The customer with Id {id} was not found.");
            }

            return Ok($"Customer with Id {id} was deleted succesfully.");
        }
    }
}