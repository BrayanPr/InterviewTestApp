using InterviewTestApp.Entities;
using InterviewTestApp.Infrestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp.Infrestructure.Repositories
{
    public class HealthCheckRepository
    {
        private readonly MyDbContext _dbContext;

        public HealthCheckRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<HealthCheck> GetHealthCheck()
        {
            return await _dbContext.HealthCheck.FirstOrDefaultAsync();
        }
    }
}
