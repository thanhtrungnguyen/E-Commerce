using AutoMapper;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.ProductDTO.Create;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<(bool IsError, string ErrorMessage)> AddProduct(CreateProductRequest cpr)
        {
            try
            {
                // add to table Products
                Product product = new Product()
                {
                    Name = cpr.Name,
                    Description = cpr.Description,
                    CategoryId = cpr.CategoryId,
                    BrandId = cpr.BrandId,
                    Sku = cpr.Sku,
                    Price = cpr.Price
                };
                await _unitOfWork.Products.Add(product);
                await _unitOfWork.CompleteAsync();
                int productId = product.Id;

                // add to table ProductOptions
                List<DAL.Entities.ProductOption> productOptions = new List<DAL.Entities.ProductOption>();
                cpr.ProductOptions.ForEach(po =>
                {
                    DAL.Entities.ProductOption productOption = new DAL.Entities.ProductOption();
                    productOption.ProductId = productId;
                    productOption.Name = po.Name;
                    productOptions.Add(productOption);
                });
                productOptions.ForEach(po =>
                {
                    _unitOfWork.ProductOptions.Add(po);
                });
                await _unitOfWork.CompleteAsync();

                // add to table ProductOptionValues
                List<ProductOptionValue> optionValues = new List<ProductOptionValue>();
                for (int i = 0; i < productOptions.Count; i++)
                {
                    cpr.ProductOptions[i].Values.ForEach(productOptionValueName =>
                    {
                        ProductOptionValue productOptionValue = new ProductOptionValue(productId, productOptions[i].Id, productOptionValueName);
                        optionValues.Add(productOptionValue);
                    });
                }
                optionValues.ForEach(pov =>
                {
                    _unitOfWork.ProductOptionValues.Add(pov);
                });
                await _unitOfWork.CompleteAsync();

                // add to table ProductSkus
                List<DAL.Entities.ProductSku> productSkus = new List<DAL.Entities.ProductSku>();
                cpr.ProductSkus.ForEach(ps =>
                {
                    DAL.Entities.ProductSku productSku = new DAL.Entities.ProductSku(productId, ps.Sku, ps.Price);
                    productSkus.Add(productSku);
                });
                productSkus.ForEach(ps =>
                {
                    _unitOfWork.ProductSkus.Add(ps);
                });
                await _unitOfWork.CompleteAsync();

                // add to table ProductSkuValues
                List<ProductSkuValue> productSkuValues = new List<ProductSkuValue>();
                int count = 0;
                for (int i = 0; i < productSkus.Count; i++)
                {
                    cpr.ProductSkus[i].OptionValueNames.ForEach(povn =>
                    {
                        count = 0;
                        optionValues.ForEach(pov =>
                        {
                            if (povn == pov.Name && count == 0)
                            {
                                ProductSkuValue psv = new ProductSkuValue(productId, productSkus[i].Id, pov.OptionId, pov.Id);
                                _unitOfWork.ProductSkuValues.Add(psv);
                                count++;
                            }
                        });
                    });
                }
                await _unitOfWork.CompleteAsync();
                return (true, productId.ToString());
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public Task<(bool IsError, string ErrorMessage)> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsError, IEnumerable<Product> products, string ErrorMessage)> GetAllProducts()
        {
            IEnumerable<Product> products = Enumerable.Empty<Product>();
            try
            {
                products = await _unitOfWork.Products.GetAll();

                return (false, products, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, products, ex.Message);
            }
        }

        public async Task<(bool IsError, Product? product, string ErrorMessage)> GetProduct(int id)
        {
            Product? product = null;
            try
            {
                product = await _unitOfWork.Products.GetProductDetailById(id);
                return (false, product, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, product, ex.Message);
            }
        }

        public async Task<(bool IsError, IEnumerable<Product>? products, string ErrorMessage)> GetProductsPagination(int page, int numberOfProducts)
        {
            IEnumerable<Product> products = Enumerable.Empty<Product>();
            try
            {
                products = await _unitOfWork.Products.GetPagination(page, numberOfProducts);

                return (false, products, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, products, ex.Message);
            }
        }

        public async Task<(bool IsError, string ErrorMessage)> UpdateProduct(int id, CreateProductRequest product)
        {
            try
            {
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
