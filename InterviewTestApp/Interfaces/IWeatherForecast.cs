using InterviewTestApp.Entities;

namespace InterviewTestApp.Interfaces
{
    public interface IWeatherForecast
    {
        List<WeatherForecast> GetAllForecasts();
        Task<WeatherForecast> GetForecast(int id);
    }
}
