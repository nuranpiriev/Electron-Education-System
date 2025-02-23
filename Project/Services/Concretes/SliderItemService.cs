using AutoMapper;
using Microsoft.CodeAnalysis.Operations;
using Project.DTOs.SliderItemDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Project.Services.Abstractions;
using Project.Utilities;

namespace Project.Services.Concretes
{
    public class SliderItemService:ISliderItemService
    {

        readonly IRepository<SliderItem> _repository;
        readonly IMapper _mapper;

        public SliderItemService(IRepository<SliderItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SliderItem> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();
       
        public async Task<SliderUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<SliderUpdateDTO>(await GetByIdAsync(id));

        public async Task<ICollection<SliderListItemDTO>> GetSliderItemListItemsAsync()
        {
            var sliders = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<SliderListItemDTO>>(sliders);
        }

        public async Task<ICollection<SliderViewItemDTO>> GetSliderItemViewItemsAsync()
        {
            var sliders = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<SliderViewItemDTO>>(sliders);
        }

        public async Task CreateAsync(SliderCreateDTO dto)
        {
            SliderItem slider = _mapper.Map<SliderItem>(dto);
            slider.ImageURL = await dto.Image.SaveAsync("sliders");
            slider.CreatedAt = DateTime.Now;

            await _repository.CreateAsync(slider);
        }

        public async Task UpdateAsync(SliderUpdateDTO dto)
        {
            SliderItem oldSliderItem = await GetByIdAsync(dto.Id);
            SliderItem slider = _mapper.Map<SliderItem>(dto);
            slider.CreatedAt = oldSliderItem.CreatedAt;
            slider.UpdatedAt = DateTime.Now;
            slider.ImageURL = dto.Image is not null ? await dto.Image.SaveAsync("sliders") : oldSliderItem.ImageURL;

            _repository.Update(slider);

            if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "sliders", oldSliderItem.ImageURL));
        }

        public async Task DeleteAsync(int id)
        {
            SliderItem slider = await GetByIdAsync(id);
            _repository.Delete(slider);
        }

        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
    }
}
