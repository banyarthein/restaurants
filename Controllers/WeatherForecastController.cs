using Microsoft.AspNetCore.Mvc;
using Restaurants.Classes;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _weatherForecastService.Get());
        }

        [HttpGet]
        [Route("today")]
        public IActionResult GetToday()
        {
            return Ok(_weatherForecastService.Get().First());
        }

        [HttpPost("generate")]
        public IActionResult Generate([FromQuery] int maxResult, [FromBody] ForecastRequest request)
        {
            if(maxResult <0 || (request.MinTemperature >= request.MaxTemperature))
            {
                return BadRequest("Max Result should be positive and Max Temperature should be higher than Min Temperature");
            }

            IEnumerable<WeatherForecast> result = _weatherForecastService.Generate(maxResult, request.MinTemperature, request.MaxTemperature);

            return Ok(result);
        }
    }
}
