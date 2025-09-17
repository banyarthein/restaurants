namespace Restaurants.Domain.Entities;

[Serializable]
public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public int KiloCalories { get; set; } = default;
    public int RestaurantId { get; set; }
}
