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
    public class ProductSkuRepository : GenericRepository<ProductSku>, IProductSkuRepository
    {
        public ProductSkuRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
