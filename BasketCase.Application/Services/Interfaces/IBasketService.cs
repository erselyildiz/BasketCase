using BasketCase.Domain.Entities;
using System.Threading.Tasks;

namespace BasketCase.Application.Services.Interfaces
{
    public interface IBasketService
    {
        Task<string> AddProductToBasket(Basket basket);
    }
}
