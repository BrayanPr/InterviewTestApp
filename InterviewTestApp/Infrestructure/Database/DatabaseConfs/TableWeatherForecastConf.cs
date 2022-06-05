using InterviewTestApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTestApp.DatabaseConfs
{
    public class TableWeatherForecastConf : IEntityTypeConfiguration<TableWeatherForecast>
    {
        public void Configure(EntityTypeBuilder<TableWeatherForecast> entity)
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

        }   
    }
}
