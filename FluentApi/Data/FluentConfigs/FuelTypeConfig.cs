using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Data.FluentConfigs;

public class FuelTypeConfig : IEntityTypeConfiguration<FuelType>
{
    public void Configure(EntityTypeBuilder<FuelType> fuelTypeEntity)
    {
        fuelTypeEntity.HasKey(ft => ft.Id);
        
        fuelTypeEntity.Property(ft => ft.FuelName)
            .IsRequired()
            .HasMaxLength(50);
    }
}