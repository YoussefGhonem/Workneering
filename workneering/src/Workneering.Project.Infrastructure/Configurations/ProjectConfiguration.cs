using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectConfiguration : IEntityTypeConfiguration<Domain.Entities.Project>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Project> builder)
    {
        builder.ToTable("Projects", "ProjectsSchema");
        builder.OwnsOne(x => x.ProjectCategory, x =>
        {
            x.Property(x => x.CategoryId).HasColumnName("CategoryId");
            x.Property(x => x.SubCategoryId).HasColumnName("SubCategoryId");
        });
    }
}