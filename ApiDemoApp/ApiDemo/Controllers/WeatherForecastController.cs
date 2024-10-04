using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController] //dieses Attribut bezieht sich nur auf die Klasse WeatherForecast... und aktiviert
                    //bestimmte Verhaltensweisen und Konventionen, die spezifisch für API Controller in ASP.net Core sind.
                    //Es wirkt sich auf alle Methoden aus, die in der Klasse als Aktionsmethoden enthalten sind.
    [Route("api/[controller]")] //wie oben beschrieben gilt dies auch für die gesamte Klasse.
                                //Es definiert den Basis URL-Pfad. [controller] ist ein Platzhalter und wird durch den Namen
                                //des Controllers ohne Suffix"Controller" ersetzt.
                                //Also WeatherForecastController wird zur URL api/weatherforecast

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast 
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
