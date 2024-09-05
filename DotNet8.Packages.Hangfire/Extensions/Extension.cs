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
    }
}
