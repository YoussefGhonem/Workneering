using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{
    public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
    {

        public CreatePortfolioCommandValidator()
        {

            RuleFor(r => r.ProjectTitle)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Template)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}