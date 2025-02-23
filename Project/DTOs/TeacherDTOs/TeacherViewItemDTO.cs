using Project.Models;
using System.Reflection.Metadata;

namespace Project.DTOs.TeacherDTOs
{
    public record TeacherViewItemDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string ImageURL {  get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Listings { get; set; }
    }
}
