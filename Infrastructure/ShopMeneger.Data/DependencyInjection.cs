using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopMeneger.Application.Interfaces;
using ShopMeneger.Application.Interfaces.IRepositories;
using ShopMeneger.Data.Context;
using ShopMeneger.Data.Repositories.ShopRepositories;

namespace ShopMeneger.Data
{
    public static class DependencyInjection
    {
        public static void AddShopMenegerData(this IServiceCollection services, ConfigurationManager configuration)
        {
            configuration.AddUserSecrets<ShopMenegerContext>().Build();

            services.AddDbContext<ShopMenegerContext>(options =>
            {
                var conectionString = configuration
                .GetConnectionString("EfCoreShopMenegerDataBase");

                options.UseSqlServer(conectionString, b => b.MigrationsAssembly(typeof(ShopMenegerContext).Assembly.FullName));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ShopMenegerContext>());

            services.AddTransient<IShopRepositories, ShopRepositories>();
        }
    }
}
