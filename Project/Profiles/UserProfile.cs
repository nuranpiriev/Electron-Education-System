using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.DTOs.UserDTOs;

namespace Project.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDTO, IdentityUser>().ReverseMap();
            CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
        }
    }

}
