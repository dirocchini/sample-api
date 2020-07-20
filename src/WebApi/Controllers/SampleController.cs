using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            try
            {
                _logger.LogInformation("Access to /index");
                return Ok($"I'm on baby! - Current Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("error")]
        public IActionResult SimulateError()
        {
            try
            {
                throw new Exception("This is an expected error");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, "this is a _logger.LogInformation");
                _logger.LogError(e, "this is a _logger.LogError");
                _logger.LogCritical(e, "this is a _logger.LogCritical");
                _logger.LogDebug(e, "this is a _logger.LogDebug");
                _logger.LogWarning(e, "this is a _logger.LogWarning");
                return BadRequest("known error");
            }
        }
    }
}