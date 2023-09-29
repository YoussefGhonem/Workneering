using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class MessageConfigurations : IEntityTypeConfiguration<Domain.Entities.Message>
{
    public void Configure(EntityTypeBuilder<Message.Domain.Entities.Message> builder)
    {
        builder.ToTable("Messages", "ChatSchema");
    }
}