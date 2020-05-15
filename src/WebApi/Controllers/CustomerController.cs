using System.Threading.Tasks;
using Application.Customers.Commands.AddNewCustomer;
using Application.Customers.Queries.GetAllCustomersWithOrders;
using Application.Customers.Queries.GetAllCustomersWithoutOrders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace WebApi.Controllers
{
    [Route("customers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var model = await Mediator.Send(new GetAllCustomerWithOrdersQuery());

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer([FromBody]AddNewCustomerCommand request)
        {
            var response = await Mediator.Send(request);
            if (!string.IsNullOrWhiteSpace(response))
                return BadRequest(response);

            return Created("AddNewCustomer", new { });
        }
    }
}