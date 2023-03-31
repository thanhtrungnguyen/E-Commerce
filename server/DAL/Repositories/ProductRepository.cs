using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Product>? GetProductDetailById(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductOptions)
                .ThenInclude(po => po.ProductOptionValues)
                .Include(p => p.ProductSkus)
                .ThenInclude(ps => ps.ProductSkuValues)
                .ThenInclude(psv => psv.ProductOptionValue)
                .Include(p => p.ProductSkus)
                .ThenInclude(ps => ps.ProductSkuValues)
                .ThenInclude(psv => psv.ProductOption)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
