
    namespace Project.Models
    {
        public class Course : Base
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl {  get; set; }
            public int LessonCount { get; set; }
            public Teacher Teacher { get; set; }
            public int TeacherId {  get; set; }
            public ICollection<Student> Students { get; set; } = new List<Student>();
            public ICollection<Attendance> Attendances { get; set; }
    }
    }

