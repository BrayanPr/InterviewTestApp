using Microsoft.AspNetCore.Mvc;

namespace InterviewTestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DbRepositoryInterface _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DbRepositoryInterface repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IActionResult Post(string id)
        {
            return Ok(_repo.GetForecast(id).Result);
        }

        [HttpGet(Name = "GetAllWeatherForecasts")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _repo.GetAllForecasts();
        }
    }
}