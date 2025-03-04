using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbFirst;

public partial class TechCommerceContext : DbContext
{
    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole(); 
    });
    
    public TechCommerceContext()
    {
    }

    public TechCommerceContext(DbContextOptions<TechCommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<AttributeValue> AttributeValues { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(loggerFactory);
        
        optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=TechCommerce; User Id=sa; Password=Elvin123; Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<AttributeValue>(entity =>
        {
            entity.HasKey(e => new { e.AttributeId, e.Value });

            entity.HasIndex(e => e.CategoryRef, "IX_AttributeValues_CategoryRef");

            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(d => d.Attribute).WithMany(p => p.AttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CategoryRefNavigation).WithMany(p => p.AttributeValues).HasForeignKey(d => d.CategoryRef);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName);

            entity.HasIndex(e => e.CategoryNameRef, "IX_Categories_CategoryNameRef");

            entity.HasOne(d => d.CategoryNameRefNavigation).WithMany(p => p.InverseCategoryNameRefNavigation)
                .HasForeignKey(d => d.CategoryNameRef)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.AttributesRefs).WithMany(p => p.CategoryRefs)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryAttribute",
                    r => r.HasOne<Attribute>().WithMany().HasForeignKey("AttributesRef"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryRef"),
                    j =>
                    {
                        j.HasKey("CategoryRef", "AttributesRef");
                        j.ToTable("CategoryAttributes");
                        j.HasIndex(new[] { "AttributesRef" }, "IX_CategoryAttributes_AttributesRef");
                    });

            entity.HasMany(d => d.ProductRefs).WithMany(p => p.CategoryRefs)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategory",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductRef"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryRef")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("CategoryRef", "ProductRef");
                        j.ToTable("ProductCategories");
                        j.HasIndex(new[] { "ProductRef" }, "IX_ProductCategories_ProductRef");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithOne(p => p.Warehouse).HasForeignKey<Warehouse>(d => d.ProductId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
