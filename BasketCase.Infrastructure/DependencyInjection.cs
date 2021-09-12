using BasketCase.Infrastructure.Contexts;
using BasketCase.Infrastructure.Contexts.Interfaces;
using BasketCase.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BasketCase.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBasketContext, BasketContext>();

            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
