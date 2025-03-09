using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Data.FluentConfigs;

public class CarTypeConfig : IEntityTypeConfiguration<CarType>
{
    public void Configure(EntityTypeBuilder<CarType> carTypeEntity)
    {
        carTypeEntity.HasKey(ct => ct.Id);
        
        carTypeEntity.Property(ct => ct.CarTypeName)
            .IsRequired()
            .HasMaxLength(50);
    }
}