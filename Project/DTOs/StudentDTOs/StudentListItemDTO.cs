using Project.Models;

namespace Project.DTOs.StudentDTOs
{
    public class StudentListItemDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CourseName {  get; set; }
        public string Email {  get; set; }
        public string TeacherName {  get; set; }
        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }
    }
}
