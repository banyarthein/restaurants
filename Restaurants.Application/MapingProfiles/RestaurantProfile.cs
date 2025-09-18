using AutoMapper;
using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.MapingProfiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantAddDTO, Restaurant>()
            .ForMember(d => d.Address, o => o.MapFrom(src => new Address
            {
                City = src.City,
                Street = src.Street,
                PostalCode = src.PostalCode
            }));


        CreateMap<Restaurant, RestaurantDTO>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
    }
}
