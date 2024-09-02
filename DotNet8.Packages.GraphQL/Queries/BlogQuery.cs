using DotNet8.Packages.DbService;
using DotNet8.Packages.DTOs;
using DotNet8.Packages.Extensions;
using DotNet8.Packages.Shared;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Packages.GraphQL.Queries
{
    public class BlogQuery
    {
        public async Task<IQueryable<BlogDto>> GetBlogsAsync([Service] AppDbContext context, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                var query = context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
                var lst = await query.Paginate(pageNo, pageSize).ToListAsync();

                return lst.Select(x => x.ToDto()).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
