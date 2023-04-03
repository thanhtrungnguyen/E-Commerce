using AutoMapper;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.BrandDTO.Create;
using DTO.BrandDTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(bool IsError, IEnumerable<Brand> Brands, string ErrorMessage)> GetAllBrands()
        {
            IEnumerable<Brand> returnedBrands = Enumerable.Empty<Brand>();
            try
            {
                returnedBrands = await _unitOfWork.Brands.GetAll();
                return (false, returnedBrands, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, returnedBrands, ex.Message);
            }
        }

        public async Task<(bool IsError, IEnumerable<Brand>? Brands, string ErrorMessage)> GetBrandsPagination(int page, int numberOfBrands)
        {
            IEnumerable<Brand> returnedBrands = Enumerable.Empty<Brand>();
            try
            {
                returnedBrands = await _unitOfWork.Brands.GetPagination(page, numberOfBrands);
                return (false, returnedBrands, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, returnedBrands, ex.Message);
            }
        }

        public async Task<(bool IsError, Brand? Brand, string ErrorMessage)> GetBrand(int id)
        {
            Brand? returnedBrand = null;
            try
            {
                returnedBrand = await _unitOfWork.Brands.GetById(id);
                return (false, returnedBrand, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, returnedBrand, ex.Message);
            }
        }
        public async Task<(bool IsError, string ErrorMessage)> AddBrand(CreateBrandRequest brand)
        {
            try
            {
                Brand newBrand = _mapper.Map<Brand>(brand);
                await _unitOfWork.Brands.Add(newBrand);
                var result = await _unitOfWork.CompleteAsync();
                return (false, result.ToString());
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }


        public async Task<(bool IsError, string ErrorMessage)> UpdateBrand(int id, UpdateBrandRequest brand)
        {
            try
            {
                var existBrand = await _unitOfWork.Brands.GetById(id);
                if (existBrand is null)
                {
                    return (true, "Not found");
                }
                Brand newBrand = _mapper.Map<Brand>(brand);
                newBrand.Id = id;
                await _unitOfWork.Brands.Update(newBrand);
                var result = await _unitOfWork.CompleteAsync();
                return (false, result.ToString());
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
        public async Task<(bool IsError, string ErrorMessage)> DeleteBrand(int id)
        {
            try
            {
                var existBrand = await _unitOfWork.Brands.GetById(id);
                if (existBrand is null)
                {
                    return (true, "Not found");
                }
                await _unitOfWork.Brands.Delete(existBrand);
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
