using DotNet8.Packages.OData.AppDbContextModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DotNet8.Packages.OData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ODataController
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Tbl_Blog> Get()
        {
            return _context.Tbl_Blogs;
        }

        [EnableQuery]
        public SingleResult<Tbl_Blog> Get([FromODataUri] int key)
        {
            var query = _context.Tbl_Blogs.Where(x => x.BlogId == key);
            return SingleResult.Create(query);
        }

        public async Task<IActionResult> Post([FromBody] Tbl_Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Tbl_Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return Created(blog);
        }
    }
}
