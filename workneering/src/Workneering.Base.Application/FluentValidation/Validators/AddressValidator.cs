using FluentValidation;
using Workneering.Base.Application.Services.DbQueryService;
using Workneering.Base.Domain.ValueObjects;

namespace Workneering.Base.Application.FluentValidation.Validators
{
    public class AddressValidator : AbstractValidator<Address?>
    {
        private readonly IDbQueryService _dbQueryService;

        public AddressValidator(IDbQueryService dbQueryService)
        {
            _dbQueryService = dbQueryService;
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x!.Street)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(200)
                .When(x => x!.Street != null);

            RuleFor(x => x!.City)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().When(x => x!.City != null)
                .Must(ValidString!).When(x => x!.City != null).WithMessage("Please add valid city");

            RuleFor(x => x!.ZipCode)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(4)
                .MaximumLength(10);

            RuleFor(x => x!.CountryId)
                .Cascade(CascadeMode.Stop)
                .MustAsync(ValideCountryId).When(x => x!.CountryId != null).WithMessage("Please add valid country");
        }

        private async Task<bool> ValideCountryId(Guid? countryId, CancellationToken cancellationToken)
        {
            if (countryId != null)
                return await _dbQueryService.IsCountryIdExistAsync(countryId.Value, cancellationToken);
            return false;
        }

        private bool ValidString(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Length >= 3 && str.Length <= 100;
        }
    }
}