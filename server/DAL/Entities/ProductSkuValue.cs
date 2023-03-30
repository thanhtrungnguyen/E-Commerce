using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductSkuValue : SaveConfig
    {

        public int ProductId { get; set; }
        public int ProductSkuId { get; set; }
        public int OptionId { get; set; }
        public int ValueId { get; set; }

        public virtual ProductSku ProductSku { get; set; }
        public virtual ProductOption ProductOption { get; set; }
        public virtual ProductOptionValue ProductOptionValue { get; set; }

        public ProductSkuValue(int productId, int productSkuId, int optionId, int valueId)
        {
            ProductId = productId;
            ProductSkuId = productSkuId;
            OptionId = optionId;
            ValueId = valueId;
        }
    }
}
