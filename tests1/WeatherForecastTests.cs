using InterviewTestApp.Controllers;
using InterviewTestApp.Infrestructure.Database;
using InterviewTestApp.Infrestructure.Repositories;
using InterviewTestApp.Interfaces;
using InterviewTestApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace tests1
{
    public class WeatherForecastTests
    {
        private readonly IWeatherForecastService _service;
        private readonly IWeatherForecastRepository _repo;
        public WeatherForecastTests()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            var context = new WeatherForecastRepository(new MyDbContext(options));
            _repo = context;
            _service = new WeatherForecastService(context);
        }
        [Fact]
        public async void CheckIndividualGet()
        {
            var result = _service.GetForecast(1);
            var expected = _repo.GetForecast(1);
            Assert.True(result.Id == 1);
        }
        [Fact]
        public void CheckAllRegisters()
        {
            var result = _service.GetAllForecasts();
            var expected = _repo.GetAllForecasts();
            
            Assert.True(expected.Count == result.Count);
        }
    }
}