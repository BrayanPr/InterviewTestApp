using InterviewTestApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTestApp.DatabaseConfs
{
    public class LstWeatherTypeConf : IEntityTypeConfiguration<LstWeatherType>
    {
        public void Configure(EntityTypeBuilder<LstWeatherType> entity)
        {
            entity.ToTable("lstWeatherType");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        }
    }
}
