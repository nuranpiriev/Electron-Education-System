using Project.DTOs.CourseDTOs;
using Project.DTOs.CourseDTOs.Project.DTOs.CourseDTOs;
using Project.Models;
namespace Project;

public interface ICourseService
{
    Task<Course> GetByIdAsync(int id);
    Task<Course> GetByIdWithOtherAsync(int id);
    Task<CourseUpdateDTO> GetByIdForUpdateAsync(int id);
    Task<ICollection<CourseListItemDTO>> GetCourseListItemsAsync();
    Task<ICollection<CourseViewItemDTO>> GetCourseViewItemsAsync();
    Task CreateAsync(CourseCreateDTO dto);
    Task UpdateAsync(CourseUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<ICollection<CourseListItemDTO>> GetAvailableCoursesAsync();
    Task<Course> GetCourseDetailsAsync(int id);
    Task<int> SaveChangesAsync();
}