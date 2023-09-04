using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectActivityConfiguration : IEntityTypeConfiguration<Domain.Entities.ProjectActivity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ProjectActivity> builder)
    {
        builder.ToTable("ProjectActivities", "ProjectsSchema");
    }
}