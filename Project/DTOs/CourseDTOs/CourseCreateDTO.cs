using FluentValidation;
using Project.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.CourseDTOs
{

    public record CourseCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId {  get; set; }
        public int LessonCount {  get; set; }
        public IFormFile Image { get; set; }

    }

    public class CourseCreateDTOValidation : AbstractValidator<CourseCreateDTO>
    {
        public CourseCreateDTOValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .MinimumLength(3).WithMessage("Name must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the Name cannot exceed 50 symbols!");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Description cannot be empty!")
                .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
                .MaximumLength(500).WithMessage("The length of the Description cannot exceed 500 symbols!");

            RuleFor(e => e.TeacherId)
               .NotEmpty().WithMessage("Teacher cannot be empty!")
               .GreaterThan(0).WithMessage("Teacher must be a natural number!"); 
            RuleFor(e => e.LessonCount)
               .NotEmpty().WithMessage("Lesson count cannot be empty!")
               .GreaterThan(0).WithMessage("Lesson count must be a natural number!");
            RuleFor(x => x.Image)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("Image cannot be null!")
               .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
               .Must(x => x.CheckType("image")).WithMessage("File must be image!");
        }

    }
}

