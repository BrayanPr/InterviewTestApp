using InterviewTestApp.Entities;
using InterviewTestApp.Infrestructure.Database;
using InterviewTestApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp.Infrestructure.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly MyDbContext _dbContext;

        public HealthCheckRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<HealthCheck> GetHealthCheck(int id)
        {
            return await _dbContext.HealthCheck.FindAsync(id);
        }
    }
}
