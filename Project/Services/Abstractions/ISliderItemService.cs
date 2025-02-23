using Project.DTOs.SliderItemDTOs;
using Project.Models;

namespace Project.Services.Abstractions
{
    public interface ISliderItemService
    {
        Task<ICollection<SliderViewItemDTO>> GetSliderItemViewItemsAsync();
        Task<ICollection<SliderListItemDTO>> GetSliderItemListItemsAsync();
        Task<SliderItem> GetByIdAsync(int id);
        Task<SliderUpdateDTO> GetByIdForUpdateAsync(int id);
        Task CreateAsync(SliderCreateDTO dto);
        Task UpdateAsync(SliderUpdateDTO dto);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
