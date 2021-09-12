using BasketCase.Application.Exceptions;
using BasketCase.Application.Services.Interfaces;
using BasketCase.Domain.Entities;
using MediatR;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BasketCase.Application.Commands.AddProductToBasket
{
    public class AddProductToBasketCommand : IRequest<string>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, string>
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;

        public AddProductToBasketCommandHandler(IProductService productService, IBasketService basketService)
        {
            this.productService = productService;
            this.basketService = basketService;
        }

        public async Task<string> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(request.ProductId, out ObjectId productId))
                throw new NotTypeOfObjectIdException("Not a BSON type ObjectId for Product.");

            var isProductStockAvailable = await productService.ProductStockControl(productId, request.Quantity);

            if (!isProductStockAvailable)
                throw new ProductOutOfStockException("Product out of stock.");

            var basketId = await basketService.AddProductToBasket(new Basket
            {
                ProductId = productId,
                Quantity = request.Quantity

            });

            _ = await productService.ProductStocQuantityUpdate(productId, request.Quantity);

            return basketId;
        }
    }
}