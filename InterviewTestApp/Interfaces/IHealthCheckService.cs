using InterviewTestApp.Entities;

namespace InterviewTestApp.Interfaces
{
    public interface IHealthCheckService
    {
        Task<string> GetHealthCheckMessage();
    }
}
