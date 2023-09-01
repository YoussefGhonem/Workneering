using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.DeleteEmploymentHistory
{
    public class DeleteEmploymentHistoryCommandValidator : AbstractValidator<DeleteEmploymentHistoryCommand>
    {

        public DeleteEmploymentHistoryCommandValidator()
        {
            RuleFor(r => r.EmploymentHistoryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}