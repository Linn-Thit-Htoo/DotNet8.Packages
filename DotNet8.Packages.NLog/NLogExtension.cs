namespace DotNet8.Packages.NLog;

public static class NLogExtension
{
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
