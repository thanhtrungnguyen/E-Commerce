using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductGalleryRepository : GenericRepository<ProductGallery>, IProductGalleryRepository
    {
        public ProductGalleryRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
