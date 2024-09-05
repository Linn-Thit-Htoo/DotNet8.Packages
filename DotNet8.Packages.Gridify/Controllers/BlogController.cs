using DotNet8.Packages.Gridify.AppDbContextModels;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Packages.Gridify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
        {
            var query = new GridifyQuery()
            {
                Page = pageNo,
                PageSize = pageSize
            };
            var blogs = await _context.Tbl_Blogs.OrderByDescending(x => x.BlogId).GridifyAsync(query);

            return Ok(blogs);
        }
    }
}
