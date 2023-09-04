using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Workneering.Project.Infrastructure.Configurations;

internal class ProposalConfiguration : IEntityTypeConfiguration<Domain.Entities.Proposal>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Proposal> builder)
    {
        builder.ToTable("Proposals", "ProjectsSchema");
    }
}