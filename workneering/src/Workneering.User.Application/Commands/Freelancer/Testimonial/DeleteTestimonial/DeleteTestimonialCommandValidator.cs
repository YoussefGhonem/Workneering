using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.DeleteTestimonial
{
    public class DeleteTestimonialCommandValidator : AbstractValidator<DeleteTestimonialCommand>
    {

        public DeleteTestimonialCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }
    }
}