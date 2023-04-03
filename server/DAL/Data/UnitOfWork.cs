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
using System.Diagnostics.Eventing.Reader;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;

        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IProductOptionRepository ProductOptions { get; private set; }

        public IProductOptionValueRepository ProductOptionValues { get; private set; }

        public IProductSkuRepository ProductSkus { get; private set; }

        public IProductSkuValueRepository ProductSkuValues { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public IUserRepository Users { get; private set; }

        public IProductGalleryRepository ProductGalleries { get; private set; }

        public IUserAddressRepository UserAddresses { get; private set; }

        public IUserPaymentRepository UserPayments { get; private set; }

        public ICartItemRepository CartItems { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public IOrderDetailRepository OrderDetails { get; private set; }

        public ISessionRepository Sessions { get; private set; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            ILogger _logger = loggerFactory.CreateLogger("logs");
            Products = new ProductRepository(context, _logger);
            Categories = new CategoryRepository(context, _logger);
            ProductOptions = new ProductOptionRepository(context, _logger);
            ProductOptionValues = new ProductOptionValueRepository(context, _logger);
            ProductSkus = new ProductSkuRepository(context, _logger);
            ProductSkuValues = new ProductSkuValueRepository(context, _logger);
            Brands = new BrandRepository(context, _logger);
            Users = new UserRepository(context, _logger);
            ProductGalleries = new ProductGalleryRepository(context, _logger);
            UserAddresses = new UserAddressRepository(context, _logger);
            UserPayments = new UserPaymentRepository(context, _logger);
            CartItems = new CartItemRepository(context, _logger);
            OrderItems = new OrderItemRepository(context, _logger);
            OrderDetails = new OrderDetailRepository(context, _logger);
            Sessions = new SessionRepository(context, _logger);
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
