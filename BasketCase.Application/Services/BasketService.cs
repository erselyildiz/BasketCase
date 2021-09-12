using BasketCase.Application.Services.Interfaces;
using BasketCase.Domain.Entities;
using BasketCase.Infrastructure.Contexts.Interfaces;
using System.Threading.Tasks;

namespace BasketCase.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<string> AddProductToBasket(Basket basket) =>
            await basketRepository.Insert(basket);
    }
}