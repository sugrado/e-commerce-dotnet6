using ECommerceBackend.Application.CorePackages.Persistence;
using ECommerceBackend.Domain.Entities.Concrete;

namespace ECommerceBackend.Application.Repositories.Products
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
