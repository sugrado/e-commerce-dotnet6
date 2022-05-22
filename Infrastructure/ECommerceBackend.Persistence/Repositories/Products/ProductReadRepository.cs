using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Application.Repositories.Products;
using ECommerceBackend.Domain.Entities.Concrete;
using ECommerceBackend.Persistence.Contexts;

namespace ECommerceBackend.Persistence.Repositories.Products
{
    public class ProductReadRepository : EfReadRepository<Product, ECommerceDbContext>, IProductReadRepository
    {
        public ProductReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
