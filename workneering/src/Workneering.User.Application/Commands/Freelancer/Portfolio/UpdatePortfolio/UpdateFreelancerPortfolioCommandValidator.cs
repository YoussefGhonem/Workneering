using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
{
    public class UpdateFreelancerPortfolioCommandValidator : AbstractValidator<UpdateFreelancerPortfolioCommand>
    {

        public UpdateFreelancerPortfolioCommandValidator()
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