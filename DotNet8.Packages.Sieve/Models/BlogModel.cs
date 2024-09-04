using Sieve.Attributes;

namespace DotNet8.Packages.Sieve.Models
{
    public class BlogModel
    {
        [Sieve(CanSort = true)]
        public int BlogId { get; set; }

        [Sieve(CanFilter = true)]
        public string BlogTitle { get; set; }

        [Sieve(CanFilter = true)]
        public string BlogAuthor { get; set; }

        [Sieve(CanFilter = true)]
        public string BlogContent { get; set; }
    }
}
