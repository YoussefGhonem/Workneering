using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Workneering.Base.Application.FluentValidation.Helpers;

public static class IdentitySettings
{
    public static PasswordOptions PasswordOptions()
    {
        return new PasswordOptions()
        {
            RequireDigit = true,
            RequireNonAlphanumeric = true,
            RequireLowercase = true,
            RequireUppercase = true,
            RequiredLength = 8,
            RequiredUniqueChars = 5,
        };
    }

    public static LockoutOptions LockoutOptions(IConfiguration configuration)
    {
        return new LockoutOptions()
        {
            DefaultLockoutTimeSpan = TimeSpan.FromHours(10),
            MaxFailedAccessAttempts = 5,
            AllowedForNewUsers = true,
        };
    }

    public static UserOptions UserOptions()
    {
        return new UserOptions()
        {
            RequireUniqueEmail = true,
        };
    }

    public static SignInOptions SignInOptions()
    {
        return new SignInOptions()
        {
            RequireConfirmedEmail = false,
            RequireConfirmedPhoneNumber = false,
        };
    }
}