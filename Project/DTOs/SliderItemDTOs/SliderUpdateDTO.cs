using FluentValidation;
using Project.Utilities;

namespace Project.DTOs.SliderItemDTOs
{
    public class SliderUpdateDTO
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string ImageURL {  get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
    public class SliderUpdateDTOValidation : AbstractValidator<SliderUpdateDTO>
    {
        public SliderUpdateDTOValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .MinimumLength(3).WithMessage("Name must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the Name cannot exceed 50 symbols!");
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Title cannot be empty!")
                .MinimumLength(3).WithMessage("Name must be at least 3 symbols long!")
                .MaximumLength(50).WithMessage("The length of the Name cannot exceed 50 symbols!");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Description cannot be empty!")
                .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
                .MaximumLength(500).WithMessage("The length of the Description cannot exceed 500 symbols!");


            RuleFor(x => x.Image)
               .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
               .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
        }

    }
}
