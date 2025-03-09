using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Data.FluentConfigs;

public class CarConfig : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> carEntity)
    {
        carEntity.HasKey(c => c.Id);
        carEntity.Property(c => c.Make).IsRequired().HasMaxLength(50);
        carEntity.Property(c => c.Model).IsRequired().HasMaxLength(50);
        carEntity.Property(c => c.Year).IsRequired();

        carEntity.HasOne(c => c.CarType)
            .WithMany(ct => ct.Cars)
            .HasForeignKey(c => c.CarTypeId);

        carEntity.HasOne(c => c.FuelType)
            .WithMany(ft => ft.Cars)
            .HasForeignKey(c => c.FuelTypeId);
        
        carEntity.HasMany(c => c.Sales)
            .WithOne(s => s.Car)
            .HasForeignKey(s => s.CarId);


    }
}