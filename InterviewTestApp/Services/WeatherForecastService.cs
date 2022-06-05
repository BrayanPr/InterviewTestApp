using InterviewTestApp.Entities;
using InterviewTestApp.Infrestructure.Repositories;
using InterviewTestApp.Interfaces;

namespace InterviewTestApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repo;
        public WeatherForecastService(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }
        public List<WeatherForecast> GetAllForecasts()
        {
            return _repo.GetAllForecasts();
        }

        public async Task<WeatherForecast> GetForecast(int id)
        {
            return await _repo.GetForecast(id);
        }
    }
}
