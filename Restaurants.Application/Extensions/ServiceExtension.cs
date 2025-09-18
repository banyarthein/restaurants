using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.MapingProfiles;
using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        // Registering the seeder
        services.AddScoped<IRestaurantsService, RestaurantsService>();

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new RestaurantProfile());
            cfg.AddProfile(new DishProfile());
        });

        return services;
    }
}
