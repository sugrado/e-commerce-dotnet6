using ECommerceBackend.Domain.Entities.Common;

namespace ECommerceBackend.Domain.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
