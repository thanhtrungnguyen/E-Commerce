using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTO.Create
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public double Price { get; set; }
        public string? Sku { get; set; }
        public List<ProductOption> ProductOptions { get; set; }
        public List<ProductSku> ProductSkus { get; set; }
    }
}
