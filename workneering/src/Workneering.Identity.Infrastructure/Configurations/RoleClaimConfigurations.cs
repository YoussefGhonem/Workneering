using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities.Claims;

namespace Workneering.Identity.Infrastructure.Configurations
{
    public class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "IdentitySchema");
        }
    }
}