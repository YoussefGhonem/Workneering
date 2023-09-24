using Workneering.Identity.Application.Services.Models;

namespace Workneering.Identity.Application.Services.DbQueryService.DbQueryService
{
	public interface IDbQueryService
    {
       public Task<UserBaseData> GetUserData(string UserRole, Workneering.Identity.Domain.Entities.User user, CancellationToken cancellationToken);
    }
}
