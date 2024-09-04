using DotNet8.Packages.Sieve.Models;

namespace DotNet8.Packages.Sieve.Db
{
    public class AppDbContext
    {
        public List<BlogModel> Blogs { get; } = new()
        {
            new(1, "Blog Title 1", "Blog Author 1", "Blog Content 1"),
            new(2, "Blog Title 2", "Blog Author 2", "Blog Content 2"),
            new(3, "Blog Title 3", "Blog Author 3", "Blog Content 3"),
            new(4, "Blog Title 4", "Blog Author 4", "Blog Content 4"),
            new(5, "Blog Title 5", "Blog Author 5", "Blog Content 5"),
            new(6, "Blog Title 6", "Blog Author 6", "Blog Content 6")
        };
    }
}
