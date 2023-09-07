using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateExperienceLevel;

public class UpdateExperienceLevelCommandValidator : AbstractValidator<UpdateExperienceLevelCommand>
{

    public UpdateExperienceLevelCommandValidator()
    {
        RuleFor(r => r.ExperienceLevel)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }
}