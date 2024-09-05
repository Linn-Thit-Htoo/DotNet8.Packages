using DotNet8.Packages.Hangfire.AppDbContextModels;
using DotNet8.Packages.Hangfire.DTOs;
using DotNet8.Packages.Hangfire.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Packages.Hangfire.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<BlogDto>> GetBlogsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var lst = await _context.Tbl_Blogs.OrderByDescending(x => x.BlogId).ToListAsync(cancellationToken: cancellationToken);
                return lst.Select(x => x.ToDto()).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> AddBlogAsync(BlogRequestDto blogRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Tbl_Blogs.AddAsync(blogRequest.ToEntity(), cancellationToken);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
