using AutoMapper;
using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO.Registration
{
    public class UserRegistrationMapper : Profile
    {
        public UserRegistrationMapper()
        {
            CreateMap<UserRegistrationRequest, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Role.Customer))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.isActivite, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.VerifyCode, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.IsEmailConfirmed, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar));
        }
    }
}
