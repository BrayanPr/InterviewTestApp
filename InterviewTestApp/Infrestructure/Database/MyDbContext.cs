using InterviewTestApp.DatabaseConfs;
using InterviewTestApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp.Infrestructure.Database
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            Database.EnsureCreated(); // DO NOT REMOVE. Needed to seed database.
        }

        public virtual DbSet<LstWeatherType> LstWeatherTypes { get; set; }
        public virtual DbSet<TableWeatherForecast> WeatherForecasts { get; set; }
        public virtual DbSet<HealthCheck> HealthCheck { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LstWeatherTypeConf());

            modelBuilder.Entity<LstWeatherType>()
                .HasData(new LstWeatherType { Id = 1, Type = "Rain" },
                new LstWeatherType { Id = 2, Type = "Snow" },
                new LstWeatherType { Id = 3, Type = "Sun" });

            modelBuilder.ApplyConfiguration(new TableWeatherForecastConf());

            modelBuilder.Entity<TableWeatherForecast>()
               .HasData(new TableWeatherForecast { Id = 1 /*Guid.Parse("c2c72824-3313-483b-8648-002ebd14c90e")*/, Date = DateTime.Now, Description = "Dreary Weather!", TemperatureCelseus = 20, WeatherTypeId = 1 },
                new TableWeatherForecast { Id = 2 /*Guid.Parse("cf25592f-8fa4-4ec4-b0da-cf5c120e8cc4")*/, Date = DateTime.Now, Description = "Cold Weather!", TemperatureCelseus = 5, WeatherTypeId = 2 },
                new TableWeatherForecast { Id = 3 /*Guid.Parse("3f9cd820-0750-4237-8fb9-263cfebe7c84")*/, Date = DateTime.Now, Description = "Hot Weather!", TemperatureCelseus = 40, WeatherTypeId = 3 });

            modelBuilder.ApplyConfiguration(new HealthCheckConf());
            modelBuilder.Entity<HealthCheck>()
                .HasData(new HealthCheck { Id = 1, Message = "OH NO!" },
                new HealthCheck { Id = 2, Message = "Everything is OK!" });
        }
    }
}
