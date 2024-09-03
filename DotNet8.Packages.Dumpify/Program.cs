using Dumpify;

public class Program
{
    public static void Main(string[] args)
    {
        new { BlogId = 1, BlogTitle = "Dumpify" }.Dump();


        var blog = new BlogModel()
        {
            BlogId = 2,
            BlogTitle = "Blog Title",
            BlogAuthor = "Blog Author",
            BlogContent = "Blog Content"
        }.Dump();
    }
}
public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}