using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateFreelancerImage
{
    public class UpdateFreelancerImageCommandValidator : AbstractValidator<UpdateFreelancerImageCommand>
    {

        public UpdateFreelancerImageCommandValidator()
        {
            RuleFor(r => r.Image)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}