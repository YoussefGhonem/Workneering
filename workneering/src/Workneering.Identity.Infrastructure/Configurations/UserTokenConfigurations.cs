using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Infrastructure.Configurations;

public class UserTokenConfigurations : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens", "IdentitySchema");
    }
}