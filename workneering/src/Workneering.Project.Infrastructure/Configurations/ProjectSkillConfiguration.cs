using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectSkillConfiguration : IEntityTypeConfiguration<Domain.Entities.ProjectSkill>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ProjectSkill> builder)
    {
        builder.ToTable("ProjectSkills", "ProjectsSchema");
    }
}