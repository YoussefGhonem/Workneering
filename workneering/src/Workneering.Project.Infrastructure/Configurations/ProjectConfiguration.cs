using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectConfiguration : IEntityTypeConfiguration<Domain.Entities.Project>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Project> builder)
    {
        builder.ToTable("Projects", "ProjectsSchema");
    }
}