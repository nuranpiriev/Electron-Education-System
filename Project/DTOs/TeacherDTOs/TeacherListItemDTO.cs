﻿namespace Project.DTOs.TeacherDTOs
{
    public class TeacherListItemDTO
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
