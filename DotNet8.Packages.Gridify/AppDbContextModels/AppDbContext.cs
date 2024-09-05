using Microsoft.EntityFrameworkCore;

namespace DotNet8.Packages.Gridify.AppDbContextModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
    }
}
