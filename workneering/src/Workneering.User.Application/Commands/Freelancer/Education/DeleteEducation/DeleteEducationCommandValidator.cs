using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Education.DeleteEducation
{
    public class DeleteEducationCommandValidator : AbstractValidator<DeleteEducationCommand>
    {

        public DeleteEducationCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}