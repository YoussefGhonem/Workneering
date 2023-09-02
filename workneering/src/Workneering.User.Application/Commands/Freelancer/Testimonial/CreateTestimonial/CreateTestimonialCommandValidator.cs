using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.CreateTestimonial
{
    public class CreateTestimonialCommandValidator : AbstractValidator<CreateTestimonialCommand>
    {

        public CreateTestimonialCommandValidator()
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