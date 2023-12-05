using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skladala.Core.Models;
using Skladala.Persistence.Models;
using Skladala.Persistence.Repository;
using Skladala.Persistence.Repository.Interfaces;

namespace Skladala.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            services.Configure<DBSetings>(configuration.GetSection("MongoDb"));
            services.AddSingleton<IRepository<FoodProductDto>, Repository<FoodProductDto>>();
            services.AddSingleton<IRepository<NonfoodProductsDto>, Repository<NonfoodProductsDto>>();
            services.AddSingleton<IRepository<AllProductDto>, Repository<AllProductDto>>();

            return services;
        }
    }
}
