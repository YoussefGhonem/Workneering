using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.UpdateTestimonial
{
    public class UpdateTestimonialCommandValidator : AbstractValidator<UpdateTestimonialCommand>
    {

        public UpdateTestimonialCommandValidator()
        {
            RuleFor(r => r.ClientTitle)
                    .Cascade(CascadeMode.Stop)
                    .NotNull()
                    .NotEmpty();

            RuleFor(r => r.LastName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.BusinessEmail)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.LinkedInProfile)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}