using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Respositories
{
    internal class RestaurantRepository(RestaurantsDBContext dBContext) : IRestaurantRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dBContext.Restaurants.ToListAsync();
            return restaurants;
        }
    }
}
