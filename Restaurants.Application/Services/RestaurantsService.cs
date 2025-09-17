using Microsoft.Extensions.Logging;
using Restaurants.Application.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services
{
    internal class RestaurantsService(IRestaurantRepository repository, ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDTO>> GetAllAsync()
        {
            logger.LogInformation("Getting all restaurants");
            IEnumerable<Restaurant> restaurants = await repository.GetAllAsync();

            IEnumerable<RestaurantDTO> restaurantDTOs = restaurants.Select(RestaurantDTO.MapFromEntity);

            return restaurantDTOs;
        }

        public async Task<RestaurantDTO> GetByIdAsync(int id)
        {
            logger.LogInformation("Getting Restaurant by ID " + id.ToString());
            Restaurant searchResult = await repository.GetByIdAsync(id);
            RestaurantDTO restaurantDTO = RestaurantDTO.MapFromEntity(searchResult);
            return restaurantDTO;
        }
    }
}
