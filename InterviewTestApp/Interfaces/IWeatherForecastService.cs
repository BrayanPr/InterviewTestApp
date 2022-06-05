using InterviewTestApp.Entities;

namespace InterviewTestApp.Interfaces
{
    public interface IWeatherForecastService
    {
        public List<WeatherForecast> GetAllForecasts();
        Task<WeatherForecast> GetForecast(int id);
    }
}
