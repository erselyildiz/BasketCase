using BasketCase.Domain.Entities;
using BasketCase.Infrastructure.Contexts;
using BasketCase.Infrastructure.Contexts.Interfaces;
using BasketCase.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BasketCase.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext basketContext;

        public BasketRepository(IOptions<DatabaseSetting> settings)
        {
            basketContext = new BasketContext(settings.Value);
        }

        public async Task<string> Insert(Basket basket)
        {
            await basketContext.Baskets.InsertOneAsync(basket);
            return basket.Id.ToString();
        }

        public async Task<Basket> GetById(ObjectId objectId) =>
             await basketContext.Baskets.Find(Builders<Basket>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

    }
}