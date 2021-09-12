using BasketCase.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketCase.Infrastructure.Contexts.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<bool> UpdateStockQuantity(ObjectId productId, int stockQuantity);
    }
}