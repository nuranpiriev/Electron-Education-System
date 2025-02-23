namespace Project.DTOs.AttendanceDTOs
{
    public class AttendanceListItemDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int LessonNumber { get; set; }
        public DateTime Date { get; set; }
    }
}