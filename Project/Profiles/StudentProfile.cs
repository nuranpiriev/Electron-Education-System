using AutoMapper;
using Project.DTOs.StudentDTOs;
using Project.Models;

namespace Project.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentCreateDTO, Student>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentListItemDTO, Student>()
                .ReverseMap()
                .ForMember(dest => dest.TeacherName, options => options.MapFrom(src => src.Course.Teacher.FullName))
                .ForMember(dest => dest.CourseName, options => options.MapFrom(src => src.Course.Name));

            CreateMap<StudentViewItemDTO, Student>()
                .ReverseMap()
                .ForMember(dest => dest.TeacherName, options => options.MapFrom(src => src.Course.Teacher.FullName))
                .ForMember(dest => dest.CourseName, options => options.MapFrom(src => src.Course.Name));
        }
    }

}
