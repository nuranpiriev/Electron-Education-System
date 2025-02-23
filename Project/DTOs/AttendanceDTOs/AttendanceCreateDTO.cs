using FluentValidation;
using Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.AttendanceDTOs
{
    public class AttendanceCreateDTO
    {
        public int CourseId { get; set; }
        public int LessonNumber { get; set; }
        public List<AttendanceRecordDTO> Students { get; set; } = new List<AttendanceRecordDTO>();
    }
    public class CreateAttendanceDTOValidator : AbstractValidator<AttendanceCreateDTO>
    {
        public CreateAttendanceDTOValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Select COURSE!")
                .GreaterThan(0).WithMessage("Select a valid course!");

            RuleFor(x => x.LessonNumber)
                .NotEmpty().WithMessage("Lesson number is required!")
                .GreaterThan(0).WithMessage("Lesson number must be greater than 0!");
        }
    }
    public class AttendanceRecordDTO
    {
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public string StudentName { get; set; }
    }
}