using DotNet8.Packages.Serilog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.Packages.Serilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Test([FromBody] BlogRequestDto blogRequest)
        {
            string jsonStr = JsonConvert.SerializeObject(blogRequest);
            _logger.LogInformation(jsonStr);

            return Ok();
        }
    }
}
