using System.Threading.Tasks;
using Application.Customers.Commands.AddNewCustomer;
using Application.Customers.Queries.GetAllCustomersWithOrders;
using Application.Customers.Queries.GetAllCustomersWithoutOrders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("customers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Return all customers without their orders (requires authentication)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWithOutOrders()
        {
            var model = await Mediator.Send(new GetAllCustomerWithoutOrdersQuery());

            return Ok(model);
        }

        /// <summary>
        /// Return all customers with their orders (requires authentication)
        /// </summary>
        /// <returns></returns>
        [HttpGet("withorders")]
        public async Task<IActionResult> GetWithOrders()
        {
            var model = await Mediator.Send(new GetAllCustomerWithOrdersQuery());

            return Ok(model);
        }

        /// <summary>
        /// Add new customer (requires authentication)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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