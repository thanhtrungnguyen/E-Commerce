using AutoMapper;
using Azure;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.CategoryDTO.Create;
using DTO.CategoryDTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(bool IsError, IEnumerable<Category> Categories, string ErrorMessage)> GetAllCategories()
        {
            IEnumerable<Category> returnedCategories = Enumerable.Empty<Category>();
            try
            {
                returnedCategories = await _unitOfWork.Categories.GetAll();
                return (false, returnedCategories, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, returnedCategories, ex.Message);
            }
        }

        public async Task<(bool IsError, IEnumerable<Category>? Categories, string ErrorMessage)> GetCategoriesPagination(int page, int numberOfCategories)
        {
            IEnumerable<Category> returnedCategories = Enumerable.Empty<Category>();
            try
            {
                returnedCategories = await _unitOfWork.Categories.GetPagination(page, numberOfCategories);
                return (false, returnedCategories, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, returnedCategories, ex.Message);
            }
        }

        public async Task<(bool IsError, Category? Category, string ErrorMessage)> GetCategory(int id)
        {
            Category? returnedCategory = null;
            try
            {
                returnedCategory = await _unitOfWork.Categories.GetById(id);
                return (false, returnedCategory, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, returnedCategory, ex.Message);
            }
        }
        public async Task<(bool IsError, string ErrorMessage)> AddCategory(CreateCategoryRequest category)
        {
            try
            {
                Category newCategory = _mapper.Map<Category>(category);
                await _unitOfWork.Categories.Add(newCategory);
                var result = await _unitOfWork.CompleteAsync();
                return (false, result.ToString());
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }


        public async Task<(bool IsError, string ErrorMessage)> UpdateCategory(int id, UpdateCategoryRequest category)
        {
            try
            {
                var existCategory = await _unitOfWork.Categories.GetById(id);
                if (existCategory is null)
                {
                    return (true, "Not found");
                }
                Category newCategory = _mapper.Map<Category>(category);
                newCategory.Id = id;
                await _unitOfWork.Categories.Update(newCategory);
                var result = await _unitOfWork.CompleteAsync();
                return (false, result.ToString());
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
        public async Task<(bool IsError, string ErrorMessage)> DeleteCategory(int id)
        {
            try
            {
                var existCategory = await _unitOfWork.Categories.GetById(id);
                if (existCategory is null)
                {
                    return (true, "Not found");
                }
                await _unitOfWork.Categories.Delete(existCategory);
                var result = await _unitOfWork.CompleteAsync();
                return (false, result.ToString());
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
