using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Settings.Domain.Entities.Refrences;

namespace Workneering.Settings.Infrastructure.Configurations;

internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills", "SettingsSchema");
    }
}