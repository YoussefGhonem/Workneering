using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workneering.Settings.Application.Services.DbQueryService;

namespace Workneering.Settings.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationSettings(this IServiceCollection services)
    {
        services.AddSingleton<IDbQueryService, DbQueryService>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}