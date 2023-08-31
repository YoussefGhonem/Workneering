using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Infrastructure.Configurations;

public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles", "IdentitySchema");
    }
}