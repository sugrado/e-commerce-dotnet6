using ECommerceBackend.Application.CorePackages.Persistence;
using ECommerceBackend.Domain.Entities.Concrete;

namespace ECommerceBackend.Application.Repositories.Orders
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
    }
}
