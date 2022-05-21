using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Domain.Entities.Common;

namespace ECommerceBackend.Application.CorePackages.Persistence
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> entities);
        Task<bool> RemoveAsync(string id);
        bool Update(TEntity model);
        Task<int> SaveAsync();
    }
}
