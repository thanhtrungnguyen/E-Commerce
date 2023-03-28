using DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DAL.Abstractions;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IProductOptionRepository Options { get; private set; }
        public IProductOptionValueRepository OptionValues { get; private set; }
        public IProductSkuRepository ProductSkus { get; private set; }
        public IProductSkuValueRepository SkuValues { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            ILogger _logger = loggerFactory.CreateLogger("logs");
            Products = new ProductRepository(context, _logger);
            Categories = new CategoryRepository(context, _logger);
            Options = new ProductOptionRepository(context, _logger);
            OptionValues = new ProductOptionValueRepository(context, _logger);
            ProductSkus = new ProductSkuRepository(context, _logger);
            SkuValues = new ProductSkuValueRepository(context, _logger);
            Brands = new BrandRepository(context, _logger);
            Users = new UserRepository(context, _logger);
        }

        public async Task<int> CompleteAsync()
        {
            var createdEntities = _context.ChangeTracker
                .Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            createdEntities.ForEach(e =>
            {
                e.Property("CreatedTime").CurrentValue = DateTime.Now;
            });

            var modifiedEntities = _context.ChangeTracker
                .Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            modifiedEntities.ForEach(e =>
            {
                e.Property("ModifiedTime").CurrentValue = DateTime.Now;
            });

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {

            _context.Dispose();
        }
    }
}
