using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateGender;

public class UpdateGenderCommandValidator : AbstractValidator<UpdateGenderCommand>
{
    public UpdateGenderCommandValidator()
    {
        RuleFor(x => x.Gender)
            .NotNull().NotEmpty().IsInEnum();
    }
}
