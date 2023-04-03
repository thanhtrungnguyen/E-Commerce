using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CartDTO.Create
{
    public class AddToCartRequest
    {
        public int ProductSkuId { get; set; }
        public int Quantity { get; set; }
    }
}
