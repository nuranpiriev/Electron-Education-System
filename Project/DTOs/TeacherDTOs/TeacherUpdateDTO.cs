using FluentValidation;
using Project.Models;
using Project.Utilities;
using System.Text.RegularExpressions;

namespace Project.DTOs.TeacherDTOs
{
    public record TeacherUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageURL {  get; set; }
        public IFormFile Image {  get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class TeacherUpdateDTOValidation : AbstractValidator<TeacherUpdateDTO>
    {
        public TeacherUpdateDTOValidation()
        {
            RuleFor(p => p.Phone)
     .NotEmpty()
     .NotNull().WithMessage("Phone Number is required.")
     .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
     .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
     .Matches(new Regex(@"^([\(]{1}[0-9]{3}[\)]{1}[\.| |\-]{0,1}|^[0-9]{3}[\.|\-| ]?)?[0-9]{3}(\.|\-| )?[0-9]{4}$")).WithMessage("PhoneNumber not valid");

            RuleFor(e => e.Email)
          .NotEmpty().WithMessage("Email cannot be empty!")
          .EmailAddress().WithMessage("Email address is wrong!");
            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Adress cannot be empty!")
                .MinimumLength(3).WithMessage("Adress must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the Adress cannot exceed 50 symbols!");

            RuleFor(e => e.Gender)
               .IsInEnum().WithMessage("Invalid gender value!");
            
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage("Id must be a natural number!");

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("First Name cannot be empty!")
                .MinimumLength(3).WithMessage("First Name must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the First Name cannot exceed 50 symbols!"); 
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("Last Name cannot be empty!")
                .MinimumLength(3).WithMessage("Last Name must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the Last Name cannot exceed 50 symbols!");
            RuleFor(x => x.Image)
               .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
               .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
        }
    }
}
