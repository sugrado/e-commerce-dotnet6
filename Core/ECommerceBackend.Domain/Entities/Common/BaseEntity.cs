namespace ECommerceBackend.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
