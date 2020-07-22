using System;
using System.Threading.Tasks;
using Application.Users.Commands.AddNewUser;
using Application.Users.Queries.GetAllUsers;
using Application.Users.Queries.GetAuthenticatedUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly ILogger _logger;

        public UserController(ILogger<UserController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Add a new user (requires authentication)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] AddNewUserCommand request)
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


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] GetAuthenticatedUserQuery request)
        {
            try
            {
                _logger.LogInformation("Trying to authenticate user {userEmail}", request.Email);
                
                var response = await Mediator.Send(request);

                _logger.LogInformation("User {userEmail} logged in", request.Email);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "error on authentication method");
                return BadRequest(e.Message);
            }
        }
    }
}