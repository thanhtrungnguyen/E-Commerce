using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface ICartService
    {
        Task<(bool IsError, string ErrorMessage)> CreateCart(int userId, int productSkuId, int quantity);
        Task<(bool IsError, string ErrorMessage)> UpdateCart(int userId, int productSkuId, int quantity);
        Task<(bool IsError, string ErrorMessage)> DeleteCart(int userId, int productSkuId, int quantity);
    }
}
