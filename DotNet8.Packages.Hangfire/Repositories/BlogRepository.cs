using DotNet8.Packages.Hangfire.AppDbContextModels;
using DotNet8.Packages.Hangfire.DTOs;
using DotNet8.Packages.Hangfire.Extensions;

namespace DotNet8.Packages.Hangfire.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
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
