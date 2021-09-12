using BasketCase.Domain.Entities;
using BasketCase.Infrastructure.Contexts.Interfaces;
using BasketCase.Infrastructure.Settings.Interfaces;
using MongoDB.Driver;

namespace BasketCase.Infrastructure.Contexts
{
    public class BasketContext : IBasketContext
    {
        public BasketContext(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Baskets = database.GetCollection<Basket>(nameof(Basket));
            Products = database.GetCollection<Product>(nameof(Product));
        }

        public IMongoCollection<Basket> Baskets { get; }
        public IMongoCollection<Product> Products { get; }
    }
}