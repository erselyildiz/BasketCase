using BasketCase.Domain.Common.Interfaces;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BasketCase.Infrastructure.Contexts.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(ObjectId objectId);
    }
}