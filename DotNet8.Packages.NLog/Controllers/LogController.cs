using DotNet8.Packages.NLog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.Packages.NLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public LogController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Test([FromBody] BlogRequestDto blogRequest)
        {
            string jsonStr = JsonConvert.SerializeObject(blogRequest);
            _logger.LogInfo(jsonStr);

            return Ok();
        }
    }
}
