using DAL.Enums;
using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderItem : Entity
    {
        public int OrderDatailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Product Product { get; set; }

    }
}
