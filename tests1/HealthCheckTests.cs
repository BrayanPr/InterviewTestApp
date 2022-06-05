using InterviewTestApp.Controllers;
using InterviewTestApp.Infrestructure.Database;
using InterviewTestApp.Infrestructure.Repositories;
using InterviewTestApp.Interfaces;
using InterviewTestApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace tests1
{
    public class HealthCheckTests
    {
        private readonly IHealthCheckService _service;
        public HealthCheckTests()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            _service = new HealthCheckService( new HealthCheckRepository(new MyDbContext(options)));
        }
        [Fact]
        public async void CheckIfReturnsOkMessage()
        {
            var result = await _service.GetHealthCheckMessage();
            Assert.True(result == "Everything is OK!");
        }
    }
}