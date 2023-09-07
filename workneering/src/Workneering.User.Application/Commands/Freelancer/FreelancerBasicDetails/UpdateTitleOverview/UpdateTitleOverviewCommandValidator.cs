using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitleOverview;

public class UpdateTitleOverviewCommandValidator : AbstractValidator<UpdateTitleOverviewCommand>
{
    public UpdateTitleOverviewCommandValidator()
    {
        RuleFor(x => x.TitleOverview)
            .NotNull().NotEmpty();
    }
}
