using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services
{
    internal class RestaurantsService(IRestaurantRepository repository, ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            logger.LogInformation("Getting all restaurants");
            IEnumerable<Restaurant> restaurants = await repository.GetAllAsync();
            return restaurants;
        }
    }
}
