using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Data.FluentConfigs;

public class SaleConfig : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> saleEntity)
    {
        saleEntity.HasKey(s => s.Id);
        
        saleEntity.Property(s => s.Date).IsRequired();
        saleEntity.Property(s => s.Price).IsRequired();

        saleEntity.HasOne(s => s.Salesman)
            .WithMany(sm => sm.Sales)
            .HasForeignKey(s => s.SalesmanId);
        
        
    }
}