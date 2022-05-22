using ECommerceBackend.Application.CorePackages.Persistence;
using ECommerceBackend.Domain.Entities.Concrete;

namespace ECommerceBackend.Application.Repositories.Customers
{
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
