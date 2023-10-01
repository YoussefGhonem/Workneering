using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class CertificationFileConfigurations : IEntityTypeConfiguration<CertifictionAttachment>
{
    public void Configure(EntityTypeBuilder<CertifictionAttachment> builder)
    {
        builder.ToTable("CertifictionAttachment", "UserSchema");
        builder.OwnsOne(x => x.FileDetails);
    }
}