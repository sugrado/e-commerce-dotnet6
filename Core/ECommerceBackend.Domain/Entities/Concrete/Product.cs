using ECommerceBackend.Domain.Entities.Common;

namespace ECommerceBackend.Domain.Entities.Concrete
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product stock info
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Product price info
        /// </summary>
        public float Price { get; set; }
    }
}
