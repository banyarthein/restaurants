﻿namespace Restaurants.Application.DTOs.Dishes;

public class DishDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public int KiloCalories { get; set; } = default;

}
