using BasketCase.Application.ViewModels;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketCase.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> ProductStockControl(ObjectId productId, int quantity);
        Task<bool> ProductStocQuantityUpdate(ObjectId productId, int quantity);
        Task<IEnumerable<ProductViewModel>> GetAll();
    }
}