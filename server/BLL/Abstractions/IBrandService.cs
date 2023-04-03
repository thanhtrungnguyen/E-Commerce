using DAL.Entities;
using DTO.BrandDTO.Create;
using DTO.BrandDTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IBrandService
    {
        Task<(bool IsError, IEnumerable<Brand> Brands, string ErrorMessage)> GetAllBrands();
        Task<(bool IsError, IEnumerable<Brand>? Brands, string ErrorMessage)> GetBrandsPagination(int page, int numberOfBrands);
        Task<(bool IsError, Brand? Brand, string ErrorMessage)> GetBrand(int id);
        Task<(bool IsError, string ErrorMessage)> AddBrand(CreateBrandRequest category);
        Task<(bool IsError, string ErrorMessage)> UpdateBrand(int id, UpdateBrandRequest category);
        Task<(bool IsError, string ErrorMessage)> DeleteBrand(int id);
    }
}
