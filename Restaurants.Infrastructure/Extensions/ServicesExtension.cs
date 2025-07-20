using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Seeder;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registering DbContext with SQL Server            
            string connectionString = configuration.GetConnectionString("RestaurantDB");
            services.AddDbContext<RestaurantsDBContext>(options => options.UseSqlServer(connectionString));

            // Registering the seeder
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

            return services;
        }
    }
}
