using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class PortfolioFileConfigurations : IEntityTypeConfiguration<PortfolioFile>
{
    public void Configure(EntityTypeBuilder<PortfolioFile> builder)
    {
        builder.ToTable("PortfolioFiles", "UserSchema");
        builder.OwnsOne(x => x.FileDetails);
    }
}