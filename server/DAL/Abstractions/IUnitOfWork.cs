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
        IBrandRepository Brands { get; }
        IUserRepository Users { get; }

        Task<int> CompleteAsync();
    }
}
