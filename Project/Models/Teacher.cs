namespace Project.Models
{
    public class Teacher:Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email {  get; set; }
        public string Address {  get; set; }
        public string ImageURL {  get; set; }
        public Gender Gender { get; set; }
        public string Phone {  get; set; }
        public ICollection<Course> Courses { get; set; } 
    }
}
