using System.Threading.Tasks;
using BasketCase.Domain.Entities;

namespace BasketCase.Infrastructure.Contexts.Interfaces
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<string> Insert(Basket basket);
    }
}