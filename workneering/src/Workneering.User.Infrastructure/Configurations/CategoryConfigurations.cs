using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<FreelancerCategory>
{
    public void Configure(EntityTypeBuilder<FreelancerCategory> builder)
    {
        builder.ToTable("Categories", "User");

    }
}