using DAL.Entities;
using DTO.ProductDTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IProductService
    {
        Task<(bool IsError, IEnumerable<Product> products, string ErrorMessage)> GetAllProducts();
        Task<(bool IsError, IEnumerable<Product>? products, string ErrorMessage)> GetProductsPagination(int page, int numberOfProducts);
        Task<(bool IsError, Product? product, string ErrorMessage)> GetProduct(int id);
        Task<(bool IsError, string ErrorMessage)> AddProduct(CreateProductRequest createProductRequest);
        Task<(bool IsError, string ErrorMessage)> UpdateProduct(Product product);
        Task<(bool IsError, string ErrorMessage)> DeleteProduct(int id);
    }
}
