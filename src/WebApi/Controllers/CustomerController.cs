using System.Threading.Tasks;
using Application.Customers.Queries.GetAllCustomersWithoutOrders;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetWithOutOrders()
        {
            var model = await Mediator.Send(new GetAllCustomerWithoutOrdersQuery());

            return Ok(model);
        }

        [HttpGet("withorders")]
        public async Task<IActionResult> GetWithOrders()
        {
            var model = await Mediator.Send(new GetAllCustomerWithoutOrdersQuery());

            return Ok(model);
        }
    }
}