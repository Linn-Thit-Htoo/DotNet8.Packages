using DotNet8.Packages.Hangfire.AppDbContextModels;
using DotNet8.Packages.Hangfire.DTOs;

namespace DotNet8.Packages.Hangfire.Repositories
{
    public interface IBlogRepository
    {
        Task<int> AddBlogAsync(BlogRequestDto blogRequest, CancellationToken cancellationToken);
        Task<IQueryable<BlogDto>> GetBlogsAsync(CancellationToken cancellationToken);
    }
}
