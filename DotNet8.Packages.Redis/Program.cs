using DotNet8.Packages.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;

public class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = ConfigurationOptions.Parse("localhost:6379");
        var redisConnection = ConnectionMultiplexer.Connect(configuration);

        var redisCache = redisConnection.GetDatabase();
        var cachedData = await GetDataWithCachingAsync(redisCache);

        Console.WriteLine($"Cached Data: {cachedData}");
        await redisConnection.CloseAsync();
    }

    private static async Task<IQueryable<BlogModel>> GetBlogs()
    {
        BlogService blogService = new();
        return await blogService.GetBlogsAsync();
    }

    private static async Task<IQueryable<BlogModel>> GetDataWithCachingAsync(IDatabase database)
    {
        string cacheKey = "Blogs";
        string data = database.StringGet(cacheKey)!;

        IQueryable<BlogModel> cachedData = default!;
        if (string.IsNullOrEmpty(data))
        {
            cachedData = await GetBlogs();
            database.StringSet(cacheKey, JsonConvert.SerializeObject(cachedData), TimeSpan.FromMinutes(1));
        }

        return cachedData;
    }
}