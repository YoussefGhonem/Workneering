using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProjectAttachmentsConfiguration : IEntityTypeConfiguration<Domain.Entities.ProjectAttachment>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ProjectAttachment> builder)
    {
        builder.ToTable("Attachments", "ProjectsSchema");
        builder.OwnsOne(i => i.ImageDetails);
    }
}