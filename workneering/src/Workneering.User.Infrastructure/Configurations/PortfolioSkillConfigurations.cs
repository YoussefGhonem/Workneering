using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class PortfolioSkillConfigurations : IEntityTypeConfiguration<PortfolioSkill>
{
    public void Configure(EntityTypeBuilder<PortfolioSkill> builder)
    {
        builder.ToTable("PortfolioSkills", "User.Portfolio");


    }
}