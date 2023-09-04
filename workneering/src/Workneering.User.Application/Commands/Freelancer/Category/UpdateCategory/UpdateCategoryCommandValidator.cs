using FluentValidation;

namespace Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {

        public UpdateCategoryCommandValidator()
        {
            RuleFor(r => r.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}