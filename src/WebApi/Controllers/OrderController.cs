using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Customers.Commands.AddNewCustomer;
using Application.Orders.Commands.AddNewOrder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : BaseController
    {
        [HttpPost("{customerId}")]
        public async Task<IActionResult> AddOrder(int customerId, [FromBody] AddNewOrderCommand request)
        {
            request.CustomerId = customerId;

            var response = await Mediator.Send(request);


            if (!string.IsNullOrWhiteSpace(response))
                return BadRequest(response);

            return Accepted();
        }
    }
}