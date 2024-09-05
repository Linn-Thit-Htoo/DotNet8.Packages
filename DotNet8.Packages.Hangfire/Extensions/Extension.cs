using DotNet8.Packages.Hangfire.AppDbContextModels;
using DotNet8.Packages.Hangfire.DTOs;

namespace DotNet8.Packages.Hangfire.Extensions
{
    public static class Extension
    {
        public static Tbl_Blog ToEntity(this BlogRequestDto blogRequest)
        {
            return new Tbl_Blog
            {
                BlogTitle = blogRequest.BlogTitle,
                BlogAuthor = blogRequest.BlogAuthor,
                BlogContent = blogRequest.BlogContent
            };
        }

        public static BlogDto ToDto(this Tbl_Blog datModel)
        {
            return new BlogDto
            {
                BlogTitle = datModel.BlogTitle,
                BlogAuthor = datModel.BlogAuthor,
                BlogContent = datModel.BlogContent
            };
        }
    }
}
