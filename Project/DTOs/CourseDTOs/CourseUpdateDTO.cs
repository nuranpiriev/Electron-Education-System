 using FluentValidation;
using Project.Utilities;

    namespace Project.DTOs.CourseDTOs
    {
        public record CourseUpdateDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl {  get; set; }
            public int TeacherId { get; set; }
            public int LessonCount {  get; set; }
            public IFormFile Image { get; set; }
    }

        public class CourseUpdateDTOValidation : AbstractValidator<CourseUpdateDTO>
        {
            public CourseUpdateDTOValidation()
            {
                RuleFor(e => e.Id)
                    .GreaterThan(0).WithMessage("Id must be a natural number!");

                RuleFor(e => e.Name)
                    .NotEmpty().WithMessage("Name cannot be empty!")
                    .MinimumLength(3).WithMessage("Name must be at least 3 symbols long!")
                    .MaximumLength(50).WithMessage("The length of the Name cannot exceed 50 symbols!");

                RuleFor(e => e.Description)
                    .NotEmpty().WithMessage("Description cannot be empty!")
                    .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
                    .MaximumLength(500).WithMessage("The length of the Description cannot exceed 500 symbols!");
            RuleFor(e => e.TeacherId)
              .NotEmpty().WithMessage("Teacher id cannot be empty!")
              .GreaterThan(0).WithMessage("Teacher id must be a natural number!");
            RuleFor(e => e.LessonCount)
              .NotEmpty().WithMessage("Lesson count cannot be empty!")
              .GreaterThan(0).WithMessage("Lesson count must be a natural number!");
            RuleFor(x => x.Image)
                .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
                .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
        }
        }
    }

