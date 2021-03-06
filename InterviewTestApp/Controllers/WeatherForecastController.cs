using InterviewTestApp.Entities;
using InterviewTestApp.Interfaces;
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
        private readonly IWeatherForecastService _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _repo.GetAllForecasts();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_repo.GetForecast(id).Result);
        }
    }
}