using AutoMapper;
using DAL.Entities;

namespace DTO.CategoryDTO.Create
{
    public class CreateCategoryMapper : Profile
    {
        public CreateCategoryMapper()
        {
            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
