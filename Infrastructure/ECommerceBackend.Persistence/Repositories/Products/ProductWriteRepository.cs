using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Application.Repositories.Products;
using ECommerceBackend.Domain.Entities.Concrete;
using ECommerceBackend.Persistence.Contexts;

namespace ECommerceBackend.Persistence.Repositories.Products
{
    public class ProductWriteRepository : EfWriteRepository<Product, ECommerceDbContext>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
