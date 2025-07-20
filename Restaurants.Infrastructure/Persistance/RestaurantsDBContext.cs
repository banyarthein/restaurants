using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistance
{
    public class RestaurantsDBContext : DbContext
    {

        public RestaurantsDBContext(DbContextOptions<RestaurantsDBContext> options, IConfiguration configuration) : base(options)
        {

        }

        internal DbSet<Restaurant> Restaurants { get; set; } = default;
        internal DbSet<Dish> Dishes { get; set; } = default;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity relationships and properties here
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(a => a.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
            // Additional configurations can be added here
        }
    }
}
