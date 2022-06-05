using InterviewTestApp.Interfaces;
using InterviewTestApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestApp.Controllers
{
    [Route("health")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHealthCheckService _repo;

        public HealthCheckController(IHealthCheckService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(_repo.GetHealthCheckMessage().Result);
        }
    }
}
