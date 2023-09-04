using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class WishlistConfiguration : IEntityTypeConfiguration<Domain.Entities.Wishlist>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wishlist> builder)
    {
        builder.ToTable("Wishlist", "ProjectsSchema");
    }
}