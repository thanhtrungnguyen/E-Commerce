using DAL.Enums;
using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserPayment : Entity
    {
        public int OrderDetailId { get; set; }
        public double Amount { get; set; }
        public string Provider { get; set; }
        public UserPaymentStatus Status { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
