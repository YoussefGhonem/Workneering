using FluentValidation;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyImage
{
    public class UpdateCompanyImageCommandValidator : AbstractValidator<UpdateCompanyImageCommand>
    {
        public UpdateCompanyImageCommandValidator()
        {
            RuleFor(r => r.Image)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}