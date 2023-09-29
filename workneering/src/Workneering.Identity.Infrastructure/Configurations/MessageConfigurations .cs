using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Infrastructure.Configurations;

public class MessageConfigurations : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages", "ChatSchema");

        // Configure the relationship with Sender
        builder.HasOne(m => m.Sender)
            .WithMany(u => u.MessagesSent);

        // Configure the relationship with Recipient
        builder.HasOne(m => m.Recipient)
            .WithMany(u => u.MessagesReceived);

    }
}