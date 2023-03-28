using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductOptionValue : Entity
    {
        public int ProductId { get; set; }
        public int OptionId { get; set; }
        public string Name { get; set; }
        public virtual ProductOption ProductOption { get; set; }
        public virtual ICollection<ProductSkuValue> ProductSkuValues { get; set; }
    }
}
