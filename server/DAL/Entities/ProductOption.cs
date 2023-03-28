using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductOption : Entity
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; }
        public virtual ICollection<ProductSkuValue> ProductSkuValues { get; set; }
    }
}
