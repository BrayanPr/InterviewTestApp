using InterviewTestApp.Entities;

namespace InterviewTestApp.Interfaces
{
    public interface IWeatherForecastRepository
    {
        public List<WeatherForecast> GetAllForecasts();
        Task<WeatherForecast> GetForecast(int id);
    }
}
