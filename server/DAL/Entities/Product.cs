using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string? Sku { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductSku> ProductSkus { get; set; }
        public virtual ICollection<ProductOption>? ProductOptions { get; set; }

        public Product()
        {
            ProductOptions = new HashSet<ProductOption>();
        }
    }
}
