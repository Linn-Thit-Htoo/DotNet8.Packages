using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Packages.Polly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(int pageNo, int pageSize)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ExampleClient");
                HttpResponseMessage response = await client.GetAsync($"/api/v1/account?pageNo={pageNo}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var jsonStr = await response.Content.ReadAsStringAsync();
                return Ok(jsonStr);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
