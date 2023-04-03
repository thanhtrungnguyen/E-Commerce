using DAL.Enums;
using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderDetail : Entity
    {

        public int UserId { get; set; }
        public int? UserAddressId { get; set; }
        public OrderDetailStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual UserAddress? UserAddress { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual UserPayment UserPayment { get; set; }
    }
}
