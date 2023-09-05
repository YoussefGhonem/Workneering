using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectCategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.ProjectCategory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ProjectCategory> builder)
    {
        builder.ToTable("ProjectCategories", "ProjectsSchema");
    }
}