using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Settings.Domain.Entities.Refrences;

namespace Workneering.Settings.Infrastructure.Configurations;

internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("SubCategories", "SettingsSchema.Refrences");
    }
}