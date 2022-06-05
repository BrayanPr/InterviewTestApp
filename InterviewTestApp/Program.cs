using InterviewTestApp.Infrestructure.Database;
using InterviewTestApp.Infrestructure.Repositories;
using InterviewTestApp.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IWeatherForecast, WeatherForecastRepository>();
builder.Services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseInMemoryDatabase("TestDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
