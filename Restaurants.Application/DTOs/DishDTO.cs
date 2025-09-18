using Restaurants.Domain.Entities;

namespace Restaurants.Application.DTOs;

public class DishDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public int KiloCalories { get; set; } = default;

    public static DishDTO MapFromEntity(Dish dish)
    {
        if (dish == null)
            return null;

        return new DishDTO
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            KiloCalories = dish.KiloCalories
        };
    }
}
