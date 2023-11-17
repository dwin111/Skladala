using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skladala.Persistence;

namespace Skladala.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection
        services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            return services;
        }
    }
}
