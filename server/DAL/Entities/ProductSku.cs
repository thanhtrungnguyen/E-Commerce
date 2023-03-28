﻿using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductSku : Entity
    {
        public int ProductId { get; set; }
        public string Sku { get; set; } = string.Empty;
        public virtual Product Product { get; set; }
        public virtual List<ProductSkuValue> ProductSkuValues { get; set; }
    }
}
