namespace Project.Models
{
    public class Attendance : Base
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int LessonNumber { get; set; }
        public DateTime Date { get; set; }
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }
}
