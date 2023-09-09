using Workneering.Base.Domain.ValueObjects;
using Workneering.User.Application.Services.Models;

namespace Workneering.User.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public Task<UserBasicInfo?> GetUserBasicInfo(Guid userId, CancellationToken cancellationToken);
    public Task<CountryDetailsDto?> GetCountryInfo(Guid userId, CancellationToken cancellationToken);
    public Task<string?> UpdateCountryUser(Guid userId, Guid? CountryId, CancellationToken cancellationToken);
    public Task<UserAddressDetailsDto?> GetAddressUser(Guid userId, CancellationToken cancellationToken);
    public Task<List<LanguagesListDto>> GetLanguagesAsync(List<Guid>? languagesIds);
}