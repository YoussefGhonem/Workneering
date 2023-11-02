using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class MessegeNotificationsConfigurations : IEntityTypeConfiguration<Domain.Entities.MessegeNotifications>
{
    public void Configure(EntityTypeBuilder<Message.Domain.Entities.MessegeNotifications> builder)
    {
        builder.ToTable("MessegeNotifications", "ChatSchema");
    }
}