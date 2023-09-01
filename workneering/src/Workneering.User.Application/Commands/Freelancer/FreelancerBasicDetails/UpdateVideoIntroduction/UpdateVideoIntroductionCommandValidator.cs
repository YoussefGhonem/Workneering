using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVideoIntroduction
{
    public class UpdateVideoIntroductionCommandValidator : AbstractValidator<UpdateVideoIntroductionCommand>
    {

        public UpdateVideoIntroductionCommandValidator()
        {
            RuleFor(r => r.LinkYoutube)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.TypeOfVideo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}