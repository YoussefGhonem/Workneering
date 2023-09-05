using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class CompanyCategoryyConfigurations : IEntityTypeConfiguration<CompanyCategory>
{
    public void Configure(EntityTypeBuilder<CompanyCategory> builder)
    {
        builder.ToTable("CompanyCategories", "UserSchema");

    }
}