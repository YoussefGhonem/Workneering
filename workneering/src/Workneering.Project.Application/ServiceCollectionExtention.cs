using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workneering.Project.Application.Services.DbQueryService;

namespace Workneering.Project.Application
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddProjectApplication(this IServiceCollection services)
        {
            services.AddSingleton<IDbQueryService, DbQueryService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}