namespace Project.Models
{
    public class AttendanceRecord : Base
    {
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool IsPresent { get; set; }
    }
}
