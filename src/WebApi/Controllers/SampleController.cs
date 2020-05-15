using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class SampleController : Controller
    {
        /// <summary>
        /// Tests if the api is online and returns the environment variable ASPNETCORE_ENVIRONMENT value
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok($"I'm on baby! - Current Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
        }
    }
}