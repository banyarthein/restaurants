using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Registering the seeder
            services.AddScoped<IRestaurantsService, RestaurantsService>();

            return services;
        }
    }
}
