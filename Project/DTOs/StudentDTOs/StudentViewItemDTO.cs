using Project.Models;

namespace Project.DTOs.StudentDTOs
{
    public record StudentViewItemDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
        public string CourseName { get; set; }
        public string TeacherName {  get; set; }
        public Gender Gender { get; set; }

    }
}
