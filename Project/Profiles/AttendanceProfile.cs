using AutoMapper;
using Project.DTOs.AttendanceDTOs;
using Project.Models;

namespace Project.Profiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<AttendanceCreateDTO, Attendance>()
    .ForMember(dest => dest.LessonNumber, opt => opt.Ignore());


            CreateMap<Attendance, AttendanceUpdateDTO>()
                .ForMember(dest => dest.LessonNumber, opt => opt.MapFrom(src => src.LessonNumber))
    .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.AttendanceRecords.Select(ar => new AttendanceRecordDTO
    {
        StudentId = ar.StudentId,
        Status = ar.IsPresent
    }).ToList()));

            CreateMap<Attendance, AttendanceListItemDTO>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

            CreateMap<Attendance, AttendanceViewDTO>()
    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
    .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.AttendanceRecords.Select(ar => new AttendanceRecordViewDTO
    {
        StudentName = ar.Student.FullName ?? "Unknown", 
        Status = ar.IsPresent
    }).ToList()));
        }
    }
}