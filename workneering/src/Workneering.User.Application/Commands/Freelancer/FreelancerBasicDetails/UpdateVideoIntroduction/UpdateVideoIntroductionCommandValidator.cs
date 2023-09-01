using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVideoIntroduction
{
    public class UpdateVideoIntroductionCommandValidator : AbstractValidator<UpdateVideoIntroductionCommand>
    {

        public UpdateVideoIntroductionCommandValidator()
        {
            RuleFor(r => r.VideoIntroductionTypeOfVideo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.VideoIntroductionLinkYoutube)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}