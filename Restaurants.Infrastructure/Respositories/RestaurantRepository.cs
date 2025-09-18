using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Respositories;

internal class RestaurantRepository(RestaurantsDBContext localDBContext) : IRestaurantRepository
{
    public async Task<int> AddAsync(Restaurant restaurant)
    {
        await localDBContext.Restaurants.AddAsync(restaurant);
        await localDBContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await localDBContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        var searchResult = await localDBContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
        return searchResult;
    }
}
