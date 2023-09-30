using Workneering.Message.Application.Services.Models;

namespace Workneering.Message.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public Task<UserInfoDto> GetUserInfo(Guid Id);
    public Task<ImageDetailsDto> GetUserImage(Guid freelancerId);
    public string GetUserRole(Guid userId);
}