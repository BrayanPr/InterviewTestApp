namespace InterviewTestApp
{
    public interface DbRepositoryInterface
    {
        List<WeatherForecast> GetAllForecasts();
        Task<WeatherForecast> GetForecast(string id);
    }
}
