using Project.DTOs.CourseDTOs.Project.DTOs.CourseDTOs;
using Project.DTOs.SliderItemDTOs;
using Project.DTOs.TeacherDTOs;

namespace Project.ViewModels
{
    public class HomeVM
    {
        public ICollection<CourseViewItemDTO> Courses { get; set; }
        public ICollection<SliderViewItemDTO> Sliders { get; set; }
        public ICollection<TeacherViewItemDTO> Teachers { get; set; }
       
    }
}
