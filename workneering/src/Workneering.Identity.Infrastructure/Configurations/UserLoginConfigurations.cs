using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Infrastructure.Configurations;

public class UserLoginConfigurations : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins", "IdentitySchema");
    }
}