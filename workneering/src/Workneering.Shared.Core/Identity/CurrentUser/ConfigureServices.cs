﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Workneering.Shared.Core.Identity.CurrentUser;
public static class ConfigureServices
{
    public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
    {
        CurrentUser.InitializeHttpContextAccessor(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        return app;
    }
}
