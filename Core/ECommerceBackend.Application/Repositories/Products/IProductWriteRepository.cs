using ECommerceBackend.Application.CorePackages.Persistence;
using ECommerceBackend.Domain.Entities.Concrete;

namespace ECommerceBackend.Application.Repositories.Products
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
