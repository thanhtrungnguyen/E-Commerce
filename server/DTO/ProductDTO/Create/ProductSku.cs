using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTO.Create
{
    public class ProductSku
    {
        public List<string> OptionValueNames { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
    }
}
