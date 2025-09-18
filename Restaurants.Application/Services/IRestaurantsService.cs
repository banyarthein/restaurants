using Restaurants.Application.DTOs.Restaurants;

namespace Restaurants.Application.Services;

public interface IRestaurantsService
{
    Task<RestaurantDTO> GetByIdAsync(int id);
    Task<IEnumerable<RestaurantDTO>> GetAllAsync();
    Task<int> AddAsync(RestaurantAddDTO addRestaurantDTO);

}