using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Shared.Support.Configuration;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<DbConnectionConfig>(options => configuration.GetSection("DbConnection").Bind(options));

            services.AddDbContext<ApplicationContextSqlServer>();
            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContextSqlServer>());

            //services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContextInMemory>());
            //services.AddDbContext<ApplicationContextInMemory>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

            return services;
        }
    }
}
