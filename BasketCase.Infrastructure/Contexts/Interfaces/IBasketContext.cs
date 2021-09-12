using BasketCase.Domain.Entities;
using MongoDB.Driver;

namespace BasketCase.Infrastructure.Contexts.Interfaces
{
    public interface IBasketContext
    {
        IMongoCollection<Basket> Baskets { get; }
        IMongoCollection<Product> Products { get; }
    }
}