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
        return data;
    }
}

