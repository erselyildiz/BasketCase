using BasketCase.Infrastructure.Contexts.Interfaces;
using BasketCase.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BasketCase.Api.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var basketContext = scope.ServiceProvider.GetRequiredService<IBasketContext>();

                    BasketContextSeed.SeedAsync(basketContext.Products).Wait();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Database migration failed! Message: {ex.Message}");
                }
            }

            return host;
        }
    }
}