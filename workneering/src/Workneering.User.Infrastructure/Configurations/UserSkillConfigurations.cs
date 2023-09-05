using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.ToTable("UserSkills", "UserSchema");
        builder.HasIndex(x => x.SkillId);

    }
}