using BasketCase.Domain.Common.Interfaces;
using MongoDB.Bson;
using System;

namespace BasketCase.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedTime => DateTime.UtcNow;
    }
}