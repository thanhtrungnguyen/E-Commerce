using AutoMapper;
using DAL.Entities;

namespace DTO.ProductDTO.Create
{
    public class CreateProductMapper : Profile
    {
        public CreateProductMapper()
        {
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            //.ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
            //.ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
