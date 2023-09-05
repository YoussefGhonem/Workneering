using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class UserSubCategoryConfigurations : IEntityTypeConfiguration<UserSubCategory>
{
    public void Configure(EntityTypeBuilder<UserSubCategory> builder)
    {
        builder.ToTable("UserSubCategories", "UserSchema");
        builder.HasIndex(x => x.SubCategoryId);
    }
}