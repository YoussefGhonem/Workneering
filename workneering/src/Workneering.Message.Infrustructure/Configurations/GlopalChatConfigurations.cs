using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class GlopalChatConfigurations : IEntityTypeConfiguration<Domain.Entities.GlopalChat>
{
    public void Configure(EntityTypeBuilder<Message.Domain.Entities.GlopalChat> builder)
    {
        builder.ToTable("GlopalChats", "ChatSchema");
    }
}