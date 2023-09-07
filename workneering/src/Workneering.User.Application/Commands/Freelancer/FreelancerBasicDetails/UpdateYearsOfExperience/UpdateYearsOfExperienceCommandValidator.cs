using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateYearsOfExperience;

public class UpdateYearsOfExperienceCommandValidator : AbstractValidator<UpdateYearsOfExperienceCommand>
{

    public UpdateYearsOfExperienceCommandValidator()
    {
        RuleFor(r => r.YearsOfExperience)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }
}