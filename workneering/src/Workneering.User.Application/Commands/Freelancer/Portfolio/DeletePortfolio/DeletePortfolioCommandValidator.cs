using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.DeletePortfolio
{
    public class DeletePortfolioCommandValidator : AbstractValidator<DeletePortfolioCommand>
    {

        public DeletePortfolioCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}