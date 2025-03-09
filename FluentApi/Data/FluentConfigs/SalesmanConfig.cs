using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Data.FluentConfigs;

public class SalesmanConfig : IEntityTypeConfiguration<Salesman>
{
    public void Configure(EntityTypeBuilder<Salesman> salesmanEntity)
    {
        salesmanEntity.HasKey(sm => sm.Id);

        salesmanEntity.Property(sm => sm.Name).IsRequired().HasMaxLength(50);
        salesmanEntity.Property(sm => sm.Surname).IsRequired();
        salesmanEntity.Property(sm => sm.PhoneNumber).IsRequired();
        
    }
}