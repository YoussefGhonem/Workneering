using Workneering.Base.Domain.ValueObjects;
using Workneering.User.Application.Services.Models;

namespace Workneering.User.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public Task<UserBasicInfo?> GetUserBasicInfo(Guid userId, CancellationToken cancellationToken);
    public Task<UserAddressDto?> GetCountryInfo(Guid userId, CancellationToken cancellationToken);
}