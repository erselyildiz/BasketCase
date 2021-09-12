using AutoMapper;
using BasketCase.Application.ViewModels;
using BasketCase.Domain.Entities;

namespace BasketCase.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}