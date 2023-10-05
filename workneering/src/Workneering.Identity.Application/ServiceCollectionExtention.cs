using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Base.Application.Extensions;
using Workneering.Shared.Core.Identity.CurrentUser;
//using Workneering.Base.Application.Services.DbQueryService;
using Workneering.Identity.Application.Services.DbQueryService;
using Microsoft.Extensions.Options;
using Workneering.Identity.Infrastructure.Helper;

namespace Workneering.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IDbQueryService, DbQueryService>();

        var googleAuthSettings = new GoogleAuthSettings();
        configuration.Bind(GoogleAuthSettings.SectionName, googleAuthSettings);
        services.AddSingleton(Options.Create(googleAuthSettings));

        var faceBookAuthSettings = new FacebookAuthSettings();
        configuration.Bind(FacebookAuthSettings.SectionName, faceBookAuthSettings);
        services.AddSingleton(Options.Create(faceBookAuthSettings));

        var linkedInAuthSettings = new LinkedInAuthSettings();
        configuration.Bind(LinkedInAuthSettings.SectionName, linkedInAuthSettings);
        services.AddSingleton(Options.Create(linkedInAuthSettings));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        #region Identity Configuration

        var config = configuration.GetJwtConfig();

        services.AddAuthorization();
        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser().Build());
        });

        services.AddIdentityCore<Identity.Domain.Entities.User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<IdentityDatabaseContext>()
            .AddTokenProvider<DataProtectorTokenProvider<Identity.Domain.Entities.User>>(TokenOptions.DefaultProvider);

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(10);
            options.Lockout.MaxFailedAccessAttempts = config.MaxFailedAccessAttempts;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var signingKey = Convert.FromBase64String(config.Key);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(signingKey)
            };
        });

        #endregion

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin() // Add your Angular app's URL here
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
        return services;
    }

    public static WebApplication UseIdentityApplication(this WebApplication app)
    {
        //app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod());
        app.UseHttpsRedirection();
        app.UseCors("AllowOrigin");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCurrentUser();

        return app;
    }


    //        #region CORS
    //    services.AddCors(options =>
    //    {
    //        options.AddPolicy("AllowAnyOriginPolicy",
    //        builder => builder
    //            .AllowAnyOrigin()  // Allow requests from any origin
    //            .AllowAnyHeader()
    //            .AllowAnyMethod());
    //    });
    //    #endregion

    //    return services;
    //}

    //public static WebApplication UseIdentityApplication(this WebApplication app)
    //{
    //    app.UseCors("AllowAnyOriginPolicy");
    //    app.UseHttpsRedirection();
    //    app.UseAuthentication();
    //    app.UseAuthorization();
    //    app.UseCurrentUser();
    //    return app;
    //}
}