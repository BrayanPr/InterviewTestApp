using InterviewTestApp.Entities;
using InterviewTestApp.Interfaces;

namespace InterviewTestApp.Services
{
    public class HealthCheckService : IHealthCheckService
    { 
        private readonly IHealthCheckRepository _repository;

        public HealthCheckService(IHealthCheckRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetHealthCheckMessage()
        {
            var response = await _repository.GetHealthCheck(2);
            
            return response.Message;
        }
    }
}
