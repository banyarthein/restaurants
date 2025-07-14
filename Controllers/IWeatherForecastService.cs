
namespace Restaurants.Controllers
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Generate(int maxResult, int minTemperature, int maxTemperature);
        IEnumerable<WeatherForecast> Get();
    }
}