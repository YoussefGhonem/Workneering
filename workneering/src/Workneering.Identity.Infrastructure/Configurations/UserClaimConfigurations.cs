using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities.Claims;

namespace Workneering.Identity.Infrastructure.Configurations;

public class UserClaimConfigurations : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims", "IdentitySchema");
    }
}