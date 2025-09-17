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

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            logger.LogInformation("Getting Restaurant by ID " + id.ToString());
            Restaurant searchResult = await repository.GetByIdAsync(id);
            return searchResult;
        }
    }
}
