using InterviewTestApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestApp.Controllers
{
    [Route("health")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHealthCheckRepository _repo;

        public HealthCheckController(ILogger<WeatherForecastController> logger, IHealthCheckRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(_repo.GetHealthCheck(2).Result.Message);
        }
    }
}
