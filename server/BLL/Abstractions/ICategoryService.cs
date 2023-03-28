using DAL.Entities;
using DTO.CategoryDTO.Create;
using DTO.CategoryDTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface ICategoryService
    {
        Task<(bool IsError, IEnumerable<Category> Categories, string ErrorMessage)> GetAllCategories();
        Task<(bool IsError, IEnumerable<Category>? Categories, string ErrorMessage)> GetCategoriesPagination(int page, int numberOfCategories);
        Task<(bool IsError, Category? Category, string ErrorMessage)> GetCategory(int id);
        Task<(bool IsError, string ErrorMessage)> AddCategory(CreateCategoryRequest category);
        Task<(bool IsError, string ErrorMessage)> UpdateCategory(int id, UpdateCategoryRequest category);
        Task<(bool IsError, string ErrorMessage)> DeleteCategory(int id);
    }
}
