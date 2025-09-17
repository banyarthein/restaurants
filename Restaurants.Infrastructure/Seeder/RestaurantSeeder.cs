using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Seeder;

public class RestaurantSeeder(RestaurantsDBContext dBContext) : IRestaurantSeeder
{


    public async Task SeedAsync()
    {
        // Check if the database is already seeded
        if (!await dBContext.Database.CanConnectAsync())
        {
            // Database is not connected, So we need to trigger migrations
            dBContext.Database.Migrate();
        }
        else if (dBContext.Database.GetPendingMigrations().Any())
        {
            // There are pending migrations, apply them
            dBContext.Database.Migrate();
        }


        if (!await dBContext.Restaurants.AnyAsync())
        {
            // Database is not seeded, proceed with seeding
            List<Restaurant> restaurants = GetRestaurantSeededData();

            await dBContext.Restaurants.AddRangeAsync(restaurants);
            await dBContext.SaveChangesAsync();
        }
        else
        {
            return; // Database is already seeded
        }

    }

    private List<Restaurant> GetRestaurantSeededData()
    {
        List<Restaurant> restaurants = new List<Restaurant>
        {
            new()
            {
                Name = "KFC",
                Description = "Famous fried chicken with global presence.",
                Category = "Fast Food",
                HasDelivery = true,
                ContactEmail = "contact@kfc.com",
                ContactNumber = "6123 4567",
                Address = new Address
                {
                    City = "Singapore",
                    Street = "Orchard Road 101",
                    PostalCode = "238841"
                },
                Dishes = new List<Dish>
                {
                    new() { Name = "Zinger Burger", Description = "Spicy chicken fillet burger", Price = 5.90m },
                    new() { Name = "2pcs Chicken Meal", Description = "Original or crispy chicken with sides", Price = 8.50m }
                }
            },
            new()
            {
                Name = "Sushi Tei",
                Description = "Elegant Japanese cuisine.",
                Category = "Japanese",
                HasDelivery = false,
                ContactEmail = "hello@sushitei.com",
                ContactNumber = "6234 7788",
                Address = new Address
                {
                    City = "Singapore",
                    Street = "Marina Bay 88",
                    PostalCode = "039594"
                },
                Dishes = new List<Dish>
                {
                    new() { Name = "Salmon Sashimi", Description = "Fresh sliced salmon", Price = 9.90m },
                    new() { Name = "Tempura Udon", Description = "Udon noodles with prawn tempura", Price = 11.50m }
                }
            },
            new()
            {
                Name = "Green Earth Café",
                Description = "Healthy vegan and vegetarian options.",
                Category = "Vegan",
                HasDelivery = true,
                ContactEmail = "info@greenearth.com",
                ContactNumber = "6888 4455",
                Address = new Address
                {
                    City = "Singapore",
                    Street = "Tampines Central 22",
                    PostalCode = "529531"
                },
                Dishes = new List<Dish>
                {
                    new() { Name = "Vegan Bowl", Description = "Quinoa, beans, tofu and more", Price = 10.90m },
                    new() { Name = "Avocado Toast", Description = "Sourdough with smashed avocado", Price = 7.50m }
                }
            },
            new()
            {
                Name = "PastaMania",
                Description = "Casual Italian pasta chain.",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "order@pastamania.com",
                ContactNumber = "6345 2211",
                Address = new Address
                {
                    City = "Singapore",
                    Street = "Changi City Point",
                    PostalCode = "486038"
                },
                Dishes = new List<Dish>
                {
                    new() { Name = "Carbonara", Description = "Creamy sauce with chicken bacon", Price = 12.00m },
                    new() { Name = "Marinara", Description = "Tomato seafood pasta", Price = 13.20m }
                }
            },
            new()
            {
                Name = "Burger Works",
                Description = "Build-your-own gourmet burger joint.",
                Category = "American",
                HasDelivery = false,
                ContactEmail = "support@burgerworks.com",
                ContactNumber = "6655 0099",
                Address = new Address
                {
                    City = "Singapore",
                    Street = "Jurong Gateway Road 333",
                    PostalCode = "608531"
                },
                Dishes = new List<Dish>
                {
                    new() { Name = "Classic Cheeseburger", Description = "Beef, cheddar, lettuce, tomato", Price = 9.90m },
                    new() { Name = "Double Stack Burger", Description = "Double patty with extra cheese", Price = 12.90m }
                }
            }

        };

        return restaurants;
    }

}