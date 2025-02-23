namespace Project.Models
{
    public class Student : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Gender Gender { get; set; }
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }

}
