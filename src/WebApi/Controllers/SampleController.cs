using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Tests if the api is online and returns the environment variable ASPNETCORE_ENVIRONMENT value
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("eita meu primeiro log loco");
            _logger.LogError("erro xpto");
            return Ok($"I'm on baby! - Current Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
        }
    }
}