using DotNet8.Packages.Sieve.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace DotNet8.Packages.Sieve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly SieveProcessor _sieveProcessor;

        public BlogController(AppDbContext context, SieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }

        // https://localhost:7277/api/Blog?Filters=BlogTitle&Sorts=BlogId&Page=1&PageSize=2
        // https://localhost:7277/api/Blog?Filters=BlogTitle%40%3DBlog%20Title%201
        // %40 => @
        // %3D => =
        [HttpGet]
        public IActionResult FilterBlogs([FromQuery] SieveModel model)
        {
            var blogs = _context.Blogs.AsQueryable();
            blogs = _sieveProcessor.Apply(model, blogs);

            return Ok(blogs);
        }
    }
}
