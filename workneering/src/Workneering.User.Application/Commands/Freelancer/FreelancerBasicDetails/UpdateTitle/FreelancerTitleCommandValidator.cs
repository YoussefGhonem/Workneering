using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitle
{
    public class FreelancerTitleCommandValidator : AbstractValidator<UpdateFreelancerTitleCommand>
    {

        public FreelancerTitleCommandValidator()
        {
            RuleFor(r => r.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}