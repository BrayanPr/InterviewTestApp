using InterviewTestApp.Entities;

namespace InterviewTestApp.Interfaces
{
    public interface IHealthCheckRepository
    {
        Task<HealthCheck> GetHealthCheck(int id);
    }
}
