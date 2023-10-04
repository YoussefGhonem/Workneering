using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Message.Infrustructure.Configurations;

public class RoomConfigurations : IEntityTypeConfiguration<Domain.Entities.Room>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Room> builder)
    {
        builder.ToTable("Rooms", "ChatSchema");
    }
}