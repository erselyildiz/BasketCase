using BasketCase.Domain.Entities;
using BasketCase.Infrastructure.Contexts;
using BasketCase.Infrastructure.Contexts.Interfaces;
using BasketCase.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketCase.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBasketContext basketContext;

        public ProductRepository(IOptions<DatabaseSetting> settings)
        {
            basketContext = new BasketContext(settings.Value);
        }

        public async Task<Product> GetById(ObjectId objectId) =>
            await basketContext.Products.Find(Builders<Product>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetAll() =>
            await basketContext.Products.Find(a => true).ToListAsync();

        public async Task<bool> UpdateStockQuantity(ObjectId productId, int stockQuantity)
        {
            var filter = Builders<Product>.Filter.Eq(f => f.Id, productId);

            var update = Builders<Product>.Update.Set(u => u.StockQuantity, stockQuantity);

            var updateResult = await basketContext.Products.UpdateOneAsync(filter, update);

            return updateResult.ModifiedCount > 0;
        }
    }
}