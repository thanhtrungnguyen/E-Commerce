using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductGallery : Entity
    {
        public int ProductId { get; set; }
        public string Url { get; set; }
        public virtual Product Product { get; set; }
    }
}
