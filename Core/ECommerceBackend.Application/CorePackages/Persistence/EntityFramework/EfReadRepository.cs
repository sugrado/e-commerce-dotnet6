using ECommerceBackend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceBackend.Application.CorePackages.Persistence.EntityFramework
{
    public class EfReadRepository<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfReadRepository(TContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.Where(p => p.Id == Guid.Parse(id)).FirstOrDefaultAsync();
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }
    }
}
