using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.DTOs.Restaurants;
using Restaurants.Application.Services;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantService.GetAllAsync();
        return Ok(restaurants);
    }

    //[HttpGet]
    //[Route("{:id}")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID([FromRoute] int id)
    {
        var restaurants = await restaurantService.GetByIdAsync(id);
        if (restaurants == null)
            return NotFound(string.Format("Restaurant with the ID {0} not found ", id));
        else
        {
            return Ok(restaurants);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RestaurantAddDTO addRestaurantDTO)
    {
        int createdID = await restaurantService.AddAsync(addRestaurantDTO);
        if (createdID > 0)
        {
            return CreatedAtAction(nameof(GetByID), new { id = createdID }, null);
        }
        else
        {
            return BadRequest();
        }
    }

}
