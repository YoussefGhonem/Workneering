using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Settings.Domain.Entities;

namespace Workneering.Settings.Infrastructure.Configurations;

internal class LanguagesConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages", "SettingsSchema");
    }
}