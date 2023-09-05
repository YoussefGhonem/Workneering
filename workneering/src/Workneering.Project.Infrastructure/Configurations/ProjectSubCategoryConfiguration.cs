using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectSubCategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.ProjectSubCategory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ProjectSubCategory> builder)
    {
        builder.ToTable("ProjectSubCategories", "ProjectsSchema");
    }
}