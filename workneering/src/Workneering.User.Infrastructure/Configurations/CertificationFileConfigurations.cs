using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class CertificationFileConfigurations : IEntityTypeConfiguration<CertifictionFile>
{
    public void Configure(EntityTypeBuilder<CertifictionFile> builder)
    {
        builder.ToTable("CertifictionFiles", "UserSchema");
        builder.OwnsOne(x => x.FileDetails);
    }
}