using AutoMapper;
using Project.DTOs.TeacherDTOs;
using Project.Models;

namespace Project.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherCreateDTO, Teacher>().ReverseMap();
            CreateMap<TeacherUpdateDTO, Teacher>().ReverseMap();
            CreateMap<TeacherListItemDTO, Teacher>().ReverseMap();
            CreateMap<TeacherViewItemDTO, Teacher>()
                .ReverseMap()
                .ForMember(dest => dest.Listings, options => options.MapFrom(src => src.Courses.Count));
        }
    }
}
