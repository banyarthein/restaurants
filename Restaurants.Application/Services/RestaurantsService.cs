using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantsService(IRestaurantRepository repository,
                                    ILogger<RestaurantsService> logger,
                                    IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDTO>> GetAllAsync()
    {
        logger.LogInformation("Getting all restaurants");
        IEnumerable<Restaurant> restaurants = await repository.GetAllAsync();
        IEnumerable<RestaurantDTO> restaurantDTOs = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

        return restaurantDTOs;
    }

    public async Task<RestaurantDTO> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting Restaurant by ID " + id.ToString());
        Restaurant restaurantFound = await repository.GetByIdAsync(id);
        RestaurantDTO restaurantDTO = mapper.Map<RestaurantDTO>(restaurantFound);

        return restaurantDTO;
    }
}
