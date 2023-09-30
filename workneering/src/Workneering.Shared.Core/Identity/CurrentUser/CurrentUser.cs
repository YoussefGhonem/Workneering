using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Shared.Core.Identity.CurrentUser;

public static class CurrentUser
{
    private static IHttpContextAccessor _httpContextAccessor;

    #region Logged In User Claims

    public static string? BaseUrl => GetBaseUrl();
    public static Guid? Id => GetClaimValue(ClaimKeys.Id) is not null ? Guid.Parse(GetClaimValue(ClaimKeys.Id)!) : null;
    public static string? Name => GetClaimValue(ClaimKeys.Name);
    public static string? Email => GetClaimValue(ClaimKeys.Email);
    public static string? ImageUrl => GetClaimValue(ClaimKeys.ImageUrl);

    public static List<RolesEnum>? Roles => GetRoles();

    #endregion

    #region Helper Methods

    private static string? GetClaimValue(string key)
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user?.Identity is null || !user.Identity.IsAuthenticated) return null;

        var value = user?.Claims?.FirstOrDefault(x => x.Type == key)?.Value;
        return value;

        // Dynamic parse from System.Type
        // This should work for all primitive types, and for types that implement IConvertible
        // return (T) Convert.ChangeType(value, typeof(T));
    }

    private static List<RolesEnum>? GetRoles()
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user?.Identity is null || !user.Identity.IsAuthenticated) return null;

        var roles = user?.Claims?
            .Where(x => x.Type == ClaimTypes.Role)
            .Select(x => Enum.Parse<RolesEnum>(x.Value))
            .ToList();
        return roles;
    }

    private static string? GetBaseUrl()
    {
        // TODO: Find a way to detect the correct schema in the production case in production it return 'http' not 'https'
        var request = _httpContextAccessor?.HttpContext?.Request;
        // return $"{request?.Scheme}://{request?.Host}{request?.PathBase}";
        return $"https://{request?.Host}{request?.PathBase}";
    }

    #endregion

    internal static void InitializeHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}