using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class MessageAttachmentsConfigurations : IEntityTypeConfiguration<Domain.Entities.MessageAttachments>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.MessageAttachments> builder)
    {
        builder.ToTable("MessageAttachments", "ChatSchema");
        builder.OwnsOne(x => x.Attachments);
    }
}