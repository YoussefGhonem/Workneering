using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class GlopalChatAttachmentsConfigurations : IEntityTypeConfiguration<Domain.Entities.GlopalChatAttachments>
{
    public void Configure(EntityTypeBuilder<Message.Domain.Entities.GlopalChatAttachments> builder)
    {
        builder.ToTable("GlopalChatAttachments", "ChatSchema");
        builder.OwnsOne(x => x.Attachments);
    }
}