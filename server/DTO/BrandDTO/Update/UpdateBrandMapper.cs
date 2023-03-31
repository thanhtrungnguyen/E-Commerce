using AutoMapper;
using DAL.Entities;
using DTO.CategoryDTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BrandDTO.Update
{
    public class UpdateBrandMapper : Profile
    {
        public UpdateBrandMapper()
        {
            CreateMap<UpdateBrandRequest, Brand>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
