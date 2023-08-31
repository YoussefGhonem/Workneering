using FluentValidation;

namespace Workneering.User.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Role)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}