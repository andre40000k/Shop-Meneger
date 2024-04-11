using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShopMeneger.DataAccess
{
    public static class DependencyInjection
    {
        public static void AddShopMenegerDataAccess(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
