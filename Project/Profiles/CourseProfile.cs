using AutoMapper;
using Project.DTOs.CourseDTOs;
using Project.DTOs.CourseDTOs.Project.DTOs.CourseDTOs;
using Project.Models;

namespace Project.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseCreateDTO, Course>().ReverseMap();
            CreateMap<CourseUpdateDTO, Course>().ReverseMap();
            CreateMap<CourseListItemDTO, Course>().ReverseMap()
                .ForMember(dest => dest.TeacherName, options => options.MapFrom(src => src.Teacher.FullName));
            CreateMap<CourseViewItemDTO, Course>()
                .ReverseMap()
                .ForMember(dest => dest.Listings, options => options.MapFrom(src => src.Students.Count))
                .ForMember(dest => dest.TeacherName, options => options.MapFrom(src => src.Teacher.FullName));
           


        }
    }
}