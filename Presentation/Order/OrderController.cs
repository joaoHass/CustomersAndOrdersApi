using Microsoft.AspNetCore.Mvc;
using Domain.Orders;

namespace Presentation
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Order>> GetCustomers()
        {
            return Ok("Not Implemented");
        }

        [HttpPost]
        [Route("")]
        public IActionResult NewCostumer([FromBody] string temporaryParameter)
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
