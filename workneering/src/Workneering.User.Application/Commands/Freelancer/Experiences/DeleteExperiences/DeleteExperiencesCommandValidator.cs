using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.DeleteExperiences
{
    public class DeleteExperiencesCommandValidator : AbstractValidator<DeleteExperiencesCommand>
    {

        public DeleteExperiencesCommandValidator()
        {
            RuleFor(r => r.ExperienceId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}