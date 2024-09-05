using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Packages.Redis
{
    public class BlogService
    {
        private readonly AppDbContext _context = new();

        public async Task<IQueryable<BlogModel>> GetBlogsAsync()
        {
            var lst = await _context.Blogs.AsNoTracking().OrderByDescending(x => x.BlogId).ToListAsync();
            return lst.AsQueryable();
        }
    }
}
