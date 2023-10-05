using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Application.Services.Models;

namespace Workneering.Message.Application.Extensions;

public static class MessageExtensions
{
    public static async Task<string> SetImageURL(this Guid userId, IDbQueryService _dbQueryService)
    {
        var image = await _dbQueryService.GetUserImage(userId);
        return image.Url;
    }

    public static async Task<UserInfoDto?> GetUserInfo(this Guid userId, IDbQueryService _dbQueryService)
    {
        var data = await _dbQueryService.GetUserInfo(userId);
        var role = _dbQueryService.GetUserRole(userId);
        var UserInfoDto = new UserInfoDto()
        {
            Title = data.Title,
            CountryName = data.CountryName,
            Name = data.Name,
            RoleName = role
        };
        return UserInfoDto;
    }
}

