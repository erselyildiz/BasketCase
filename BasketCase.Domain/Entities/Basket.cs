using BasketCase.Domain.Common;
using MongoDB.Bson;

namespace BasketCase.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public ObjectId ProductId { get; set; }
        public int Quantity { get; set; }
    }
}