namespace DotNet8.Packages.NewtonSoft;

public class Program
{
    public static void Main(string[] args)
    {
        #region C# object to JSON

        var blog = new BlogModel()
        {
            BlogId = 1,
            BlogTitle = "Sample Title",
            BlogAuthor = "Sample Author",
            BlogContent = "Sample Content"
        };
        string jsonStr = blog.ToJson();
        Console.WriteLine(jsonStr);

        #endregion

        #region JSON to C# object

        var obj = jsonStr.ToObject<BlogModel>();
        Console.WriteLine(obj.BlogId);

        #endregion
    }
}
