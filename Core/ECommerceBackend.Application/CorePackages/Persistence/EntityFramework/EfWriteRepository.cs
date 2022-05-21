using ECommerceBackend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceBackend.Application.CorePackages.Persistence.EntityFramework
{
    public class EfWriteRepository<TEntity, TContext> : IWriteRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfWriteRepository(TContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.Entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return entities;
        }

        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            TEntity model = await Table.Where(p => p.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            return Remove(model);
        }

        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }
}
