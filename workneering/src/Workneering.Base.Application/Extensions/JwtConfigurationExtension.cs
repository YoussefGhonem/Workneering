using Microsoft.Extensions.Configuration;
using Workneering.Base.Application.Models;

namespace Workneering.Base.Application.Extensions;

public static class JwtConfigurationExtension
{
    public static JwtConfig GetJwtConfig(this IConfiguration configuration)
    {
        var config = configuration.GetSection("Jwt").Get<JwtConfig>();
        if (config is null)
        {
            throw new Exception("Missing 'Jwt' configuration section from the appsettings.");
        }

        return config;
    }
}