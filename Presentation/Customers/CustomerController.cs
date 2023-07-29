using Microsoft.AspNetCore.Mvc;
using Domain.Customers;
using Presentation.Customers.Dtos;
using System.Net.Mime;
using Presentation.Customers.Service;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCustomerById(int id)
        {
            Customer? customer = _service.Get(id);

            if (customer == null)
                return NotFound($"The customer with Id {id} was not found.");

            return Ok(customer);
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
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

        [Authorize]
        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                _service.Update(id, customerUpdateDto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("The customer was updated succesfully.");
        }

        [Authorize]
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