using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) {
            this.Database.EnsureCreated(); // DO NOT REMOVE. Needed to seed database.
        }

        public virtual DbSet<LstWeatherType> LstWeatherTypes { get; set; } = null!;
        public virtual DbSet<TableWeatherForecast> WeatherForecasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LstWeatherType>(entity =>
            {
                entity.ToTable("lstWeatherType");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });
            modelBuilder.Entity<LstWeatherType>()
                .HasData(new LstWeatherType { Id = 1, Type = "Rain" },
                new LstWeatherType { Id = 2, Type = "Snow" },
                new LstWeatherType { Id = 3, Type = "Sun" });

            modelBuilder.Entity<TableWeatherForecast>(entity =>
            {
                entity.ToTable("weatherForecast");
                entity.Property(e => e.Id)
                    .HasColumnName("id");
                entity.Property(e => e.Date)
                    .HasColumnName("date");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.TemperatureCelseus)
                    .HasColumnName("tempc");
                entity.HasOne(e => e.WeatherType)
                    .WithMany(w => w.WeatherForecasts)
                    .HasForeignKey(x => x.WeatherTypeId);
            });
            modelBuilder.Entity<TableWeatherForecast>()
                .HasData(new TableWeatherForecast { Id = Guid.Parse("c2c72824-3313-483b-8648-002ebd14c90e"), Date = DateTime.Now, Description = "Dreary Weather!", TemperatureCelseus = 20, WeatherTypeId = 1 },
                new TableWeatherForecast { Id = Guid.Parse("cf25592f-8fa4-4ec4-b0da-cf5c120e8cc4"), Date = DateTime.Now, Description = "Cold Weather!", TemperatureCelseus = 5, WeatherTypeId = 2 },
                new TableWeatherForecast { Id = Guid.Parse("3f9cd820-0750-4237-8fb9-263cfebe7c84"), Date = DateTime.Now, Description = "Hot Weather!", TemperatureCelseus = 40, WeatherTypeId = 3 });

            modelBuilder.Entity<HealthCheck>(entity =>
            {
                entity.ToTable("healthCheck");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Message).HasColumnName("message");
            });
            modelBuilder.Entity<HealthCheck>()
                .HasData(new HealthCheck { Id = 1, Message = "OH NO!"},
                new HealthCheck { Id = 2, Message = "Everything is OK!" });
        }
    }
}
