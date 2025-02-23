using AutoMapper;
using Project.DTOs.SliderItemDTOs;
using Project.Models;

namespace Project.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderCreateDTO, SliderItem>().ReverseMap();
            CreateMap<SliderUpdateDTO, SliderItem>().ReverseMap();
            CreateMap<SliderListItemDTO, SliderItem>().ReverseMap();
            CreateMap<SliderViewItemDTO, SliderItem>()
                .ReverseMap();
                
        }
    }
}
