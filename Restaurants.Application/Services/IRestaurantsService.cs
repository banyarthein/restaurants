using Restaurants.Application.DTOs;

namespace Restaurants.Application.Services;

public interface IRestaurantsService
{
    Task<RestaurantDTO> GetByIdAsync(int id);
    Task<IEnumerable<RestaurantDTO>> GetAllAsync();
}