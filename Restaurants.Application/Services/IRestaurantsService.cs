using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services
{
    public interface IRestaurantsService
    {
        Task<Restaurant> GetByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
    }
}