using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shared.Support.ClassExtensions;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    hostContext.Configuration = ConfigurationsExtensions.ConfigureDefaultJson(hostContext.HostingEnvironment.EnvironmentName).Build();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
