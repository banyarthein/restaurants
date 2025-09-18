using AutoMapper;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.MapingProfiles;

internal class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDTO>();
    }
}
