using System;
using System.Threading.Tasks;

namespace Zeng.Prototypes.Projection.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task SaveChangesAsync();
    }
}