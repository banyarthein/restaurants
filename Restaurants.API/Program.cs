using Restaurants.API.Controllers;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await services.SeedAsync();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
