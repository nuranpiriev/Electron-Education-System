using Project.DTOs.StudentDTOs;
using Project.Models;

namespace Project.Services.Abstractions
{
    public interface IStudentService
    {
        Task<ICollection<StudentViewItemDTO>> GetStudentViewItemsAsync();
        Task<ICollection<StudentListItemDTO>> GetStudentListItemsAsync();
        Task<Student> GetByIdAsync(int id);
        Task<StudentUpdateDTO> GetByIdForUpdateAsync(int id);
        Task CreateAsync(StudentCreateDTO dto);
        Task UpdateAsync(StudentUpdateDTO dto);
        Task DeleteAsync(int id);
        Task<Student> GetStudentDetailsAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
