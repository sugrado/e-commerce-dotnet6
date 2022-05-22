using ECommerceBackend.Application.CorePackages.Persistence.EntityFramework;
using ECommerceBackend.Application.Repositories.Customers;
using ECommerceBackend.Domain.Entities.Concrete;
using ECommerceBackend.Persistence.Contexts;

namespace ECommerceBackend.Persistence.Repositories.Customers
{
    public class CustomerReadRepository : EfReadRepository<Customer, ECommerceDbContext>, ICustomerReadRepository
    {
        public CustomerReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
