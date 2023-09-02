using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.ReplyTestimonial
{
    public class ReplyTestimonialCommandValidator : AbstractValidator<ReplyTestimonialCommand>
    {

        public ReplyTestimonialCommandValidator()
        {
            RuleFor(r => r.ReplyMessage)
                    .Cascade(CascadeMode.Stop)
                    .NotNull()
                    .NotEmpty();

            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }

    }
}