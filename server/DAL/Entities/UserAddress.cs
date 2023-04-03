using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserAddress : Entity
    {
        public int UserId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
    }
}
