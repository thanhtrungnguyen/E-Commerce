using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IProductOptionRepository ProductOptions { get; }
        IProductOptionValueRepository ProductOptionValues { get; }
        IProductSkuRepository ProductSkus { get; }
        IProductSkuValueRepository ProductSkuValues { get; }
        IProductGalleryRepository ProductGalleries { get; }
        IBrandRepository Brands { get; }
        IUserRepository Users { get; }
        IUserAddressRepository UserAddresses { get; }
        IUserPaymentRepository UserPayments { get; }
        ICartItemRepository CartItems { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderDetailRepository OrderDetails { get; }
        ISessionRepository Sessions { get; }


        Task<int> CompleteAsync();
    }
}
