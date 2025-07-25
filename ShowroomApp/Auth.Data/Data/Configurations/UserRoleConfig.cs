using Auth.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.Data.Configurations;

public class UserRoleConfig  : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => ur.Id);

        builder.HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
            .HasForeignKey("FK_UserRoles_Role");
        
        builder.HasOne(ur => ur.User).WithMany(r => r.UserRoles)
            .HasForeignKey("FK_UserRoles_User");


    }
}