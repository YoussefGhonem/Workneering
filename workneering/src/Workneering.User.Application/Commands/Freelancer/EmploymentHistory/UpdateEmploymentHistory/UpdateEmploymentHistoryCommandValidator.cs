using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.UpdateEmploymentHistory
{
    public class UpdateEmploymentHistoryCommandValidator : AbstractValidator<UpdateEmploymentHistoryCommand>
    {

        public UpdateEmploymentHistoryCommandValidator()
        {
            RuleFor(r => r.EmploymentHistoryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}