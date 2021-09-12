using AutoMapper;
using BasketCase.Application.Exceptions;
using BasketCase.Application.Services.Interfaces;
using BasketCase.Application.ViewModels;
using BasketCase.Infrastructure.Contexts.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketCase.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var products = await productRepository.GetAll();
            if (products is null)
                throw new ProductNotFoundException($"Product not found");

            return mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<bool> ProductStockControl(ObjectId productId, int quantity)
        {
            var product = await productRepository.GetById(productId);
            if (product is null)
                throw new ProductNotFoundException($"Product not found with object id {productId}");

            return product.StockQuantity - product.MinimumStockQuantity >= quantity;
        }

        public async Task<bool> ProductStocQuantityUpdate(ObjectId productId, int quantity)
        {
            var product = await productRepository.GetById(productId);
            if (product is null)
                throw new ProductNotFoundException($"Product not found with object id {productId}");

            return await productRepository.UpdateStockQuantity(productId, product.StockQuantity - quantity);
        }
    }
}