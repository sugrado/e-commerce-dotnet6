using ECommerceBackend.Domain.Entities.Common;
using ECommerceBackend.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnSaving()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            DateTime now = DateTime.Now;
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Deleted:
                        data.Entity.Deleted = true;
                        data.Entity.ModifiedAt = now;
                        break;
                    case EntityState.Modified:
                        data.Entity.ModifiedAt = now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = now;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
