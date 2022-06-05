using InterviewTestApp.Entities;

namespace InterviewTestApp
{
    public interface WeatherForecastInterface
    {
        List<WeatherForecast> GetAllForecasts();
        Task<WeatherForecast> GetForecast(int id);
        Task<HealthCheck> GetHealthCheck();
    }
}
