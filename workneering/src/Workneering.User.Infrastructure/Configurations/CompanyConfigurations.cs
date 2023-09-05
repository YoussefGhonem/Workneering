using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Infrastructure.Configurations;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "UserSchema");

        builder.OwnsOne(z => z.ReviewersStars, x =>
            {
                x.Property(x => x.NumberOfReviewersOneStars).HasColumnName("NumberOfReviewersOneStars");
                x.Property(x => x.NumberOfReviewersTowStars).HasColumnName("NumberOfReviewersTowStars");
                x.Property(x => x.NumberOfReviewersThreeStars).HasColumnName("NumberOfReviewersThreeStars");
                x.Property(x => x.NumberOfReviewersFourStars).HasColumnName("NumberOfReviewersFourStars");
                x.Property(x => x.NumberOfReviewersFiveStars).HasColumnName("NumberOfReviewersFiveStars");
            });
    }
}