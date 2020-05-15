using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class SampleController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("I'm on baby!");
        }
    }
}