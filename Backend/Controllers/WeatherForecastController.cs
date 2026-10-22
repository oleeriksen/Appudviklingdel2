using Core;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    [Route("random/{n:int=1}")]
    public IEnumerable<WeatherForecast> Get(int n)
    {
        return Enumerable.Range(1, n).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpGet]
    [Route("varm/{n:int=1}")]
    public IEnumerable<WeatherForecast> Get1(int n)
    {
        WeatherForecast[] result = new WeatherForecast[n];
        for (int index = 1; index <= n; index++)
            result[index - 1] = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(12, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        return result;
    }
}