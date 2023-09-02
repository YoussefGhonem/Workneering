using Workneering.Base.Domain.ValueObjects;

namespace Workneering.Base.Application.Services.DbQueryService;

public interface IDbQueryService
{
    Task<bool> IsCountryIdExistAsync(Guid countryId, CancellationToken cancellationToken);
    Task<AddressCountryDto> GetAddressCountryDtoByIdAsync(Guid? countryId);
}