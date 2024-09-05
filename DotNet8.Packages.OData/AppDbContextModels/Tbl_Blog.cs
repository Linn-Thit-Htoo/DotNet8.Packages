using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8.Packages.OData.AppDbContextModels
{
    [Table("Tbl_Blog")]
    public class Tbl_Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
