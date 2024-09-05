using DotNet8.Packages.Log4net.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.Packages.Log4net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILog _logger;

        public LogController(ILog logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Test([FromBody] BlogRequestDto blogRequest)
        {
            string jsonStr = JsonConvert.SerializeObject(blogRequest);
            _logger.Info(jsonStr);

            return Ok();
        }
    }
}
