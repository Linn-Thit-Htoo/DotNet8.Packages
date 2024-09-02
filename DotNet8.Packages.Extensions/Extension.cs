using DotNet8.Packages.DbService;
using DotNet8.Packages.DTOs.Blog;

namespace DotNet8.Packages.Extensions
{
    public static class Extension
    {
        public static BlogDto ToDto(this Tbl_Blog dataModel)
        {
            return new BlogDto
            {
                BlogId = dataModel.BlogId,
                BlogTitle = dataModel.BlogTitle,
                BlogAuthor = dataModel.BlogAuthor,
                BlogContent = dataModel.BlogContent
            };
        }
    }
}
