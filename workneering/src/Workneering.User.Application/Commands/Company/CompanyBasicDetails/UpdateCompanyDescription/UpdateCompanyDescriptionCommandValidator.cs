using FluentValidation;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyDescription
{
    public class UpdateCompanyDescriptionCommandValidator : AbstractValidator<UpdateCompanyDescriptionCommand>
    {

        public UpdateCompanyDescriptionCommandValidator()
        {
            RuleFor(r => r.OverviewDescription)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();



        }

    }
}