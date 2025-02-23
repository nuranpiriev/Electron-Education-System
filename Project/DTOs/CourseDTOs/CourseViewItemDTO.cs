namespace Project.DTOs.CourseDTOs
{
    namespace Project.DTOs.CourseDTOs
    {
        public record CourseViewItemDTO
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string TeacherName {  get; set; }
            public string LessonCount {  get; set; }
            public string ImageUrl {  get; set; }
            public int Listings {  get; set; }
        }
        public class CourseDetailsDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string TeacherName { get; set; }
            public string ImageUrl { get; set; }
            public int LessonCount { get; set; }
            public List<StudentAttendanceDTO> StudentAttendances { get; set; } = new List<StudentAttendanceDTO>();
        }

        public class StudentAttendanceDTO
        {
            public string StudentName { get; set; }
            public List<string> AttendanceStatus { get; set; } = new List<string>();
        }
    }
}
