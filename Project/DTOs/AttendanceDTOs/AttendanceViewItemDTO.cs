namespace Project.DTOs.AttendanceDTOs
{
    public class AttendanceViewDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int LessonNumber { get; set; }
        public DateTime Date { get; set; }
        public List<AttendanceRecordViewDTO> Students { get; set; } = new List<AttendanceRecordViewDTO>();
    }

    public class AttendanceRecordViewDTO
    {
        public string StudentName { get; set; }
        public bool Status { get; set; }
    }
}