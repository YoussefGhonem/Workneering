using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Category.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator()
        {

            RuleFor(r => r.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }

    }
}