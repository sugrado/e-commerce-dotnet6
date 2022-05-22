using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Application.Repositories.Orders;
using ECommerceBackend.Domain.Entities.Concrete;
using ECommerceBackend.Persistence.Contexts;

namespace ECommerceBackend.Persistence.Repositories.Orders
{
    public class OrderWriteRepository : EfWriteRepository<Order, ECommerceDbContext>, IOrderWriteRepository
    {
        public OrderWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
