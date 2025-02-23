using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.AttendanceDTOs
{
    public class AttendanceUpdateDTO
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; }
        public List<AttendanceRecordDTO> Students { get; set; } = new List<AttendanceRecordDTO>();
    }
}