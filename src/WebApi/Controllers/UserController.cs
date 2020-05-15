using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Users.Commands.AddNewUser;
using Application.Users.Queries.GetAuthenticatedUserQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody]AddNewUserCommand request)
        {
            try
            {
                var response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody]GetAuthenticatedUserQuery request)
        {
            try
            {
                var response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}