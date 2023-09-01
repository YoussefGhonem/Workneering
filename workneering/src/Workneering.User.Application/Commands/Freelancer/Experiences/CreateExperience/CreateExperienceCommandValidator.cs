using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.CreateExperience
{
    public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
    {

        public CreateExperienceCommandValidator()
        {

            RuleFor(r => r.Subject)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}