using log4net;
using log4net.Config;

namespace DotNet8.Packages.Log4net;

public static class Log4netExtensions
{
    public static void AddLog4net(this IServiceCollection services)
    {
        XmlConfigurator.Configure(new FileInfo("log4net.config"));
        services.AddSingleton(LogManager.GetLogger(typeof(Program)));
    }
}
