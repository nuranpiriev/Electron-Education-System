using Project.DTOs.AttendanceDTOs;
using Project.DTOs.CourseDTOs;
using Project.Models;

namespace Project.Services.Abstractions
{
    public interface IAttendanceService
    {
        Task<Attendance> GetByIdAsync(int id);
        Task<Attendance> GetByIdWithOtherAsync(int id);
        Task<AttendanceCreateDTO> GetByIdForCreateAsync(int courseId);
        Task<AttendanceUpdateDTO> GetByIdForUpdateAsync(int id);
        Task<ICollection<AttendanceListItemDTO>> GetAttendanceListItemsAsync();
        Task CreateAsync(AttendanceCreateDTO dto);
        Task UpdateAsync(AttendanceUpdateDTO dto);
        Task DeleteAsync(int id);
        
        Task<int> SaveChangesAsync();
    }
}