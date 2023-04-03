using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductDiscount : Entity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
