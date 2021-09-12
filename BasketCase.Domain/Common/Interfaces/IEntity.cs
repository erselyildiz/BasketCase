using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BasketCase.Domain.Common.Interfaces
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        DateTime CreatedTime { get; }
    }
}