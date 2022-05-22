using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Application.Repositories.Customers;
using ECommerceBackend.Domain.Entities.Concrete;
using ECommerceBackend.Persistence.Contexts;

namespace ECommerceBackend.Persistence.Repositories.Customers
{
    public class CustomerWriteRepository : EfWriteRepository<Customer, ECommerceDbContext>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
