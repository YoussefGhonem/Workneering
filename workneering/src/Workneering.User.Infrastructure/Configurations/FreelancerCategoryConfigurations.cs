using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class FreelancerCategoryConfigurations : IEntityTypeConfiguration<FreelancerCategory>
{
    public void Configure(EntityTypeBuilder<FreelancerCategory> builder)
    {
        builder.ToTable("FreelancerCategories", "UserSchema");

    }
}