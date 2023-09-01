using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {

        public UpdateCategoryCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

        }

    }
}