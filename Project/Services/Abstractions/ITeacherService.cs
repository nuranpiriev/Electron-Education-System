using Project.DTOs.TeacherDTOs;
using Project.Models;

namespace Project.Services.Abstractions
{
    public interface ITeacherService
    {
        Task<ICollection<TeacherViewItemDTO>> GetTeacherViewItemsAsync();
        Task<ICollection<TeacherListItemDTO>> GetTeacherListItemsAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> GetByIdWithOtherAsync(int id);
        Task<TeacherUpdateDTO> GetByIdForUpdateAsync(int id);
        Task CreateAsync(TeacherCreateDTO dto);
        Task UpdateAsync(TeacherUpdateDTO dto);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
