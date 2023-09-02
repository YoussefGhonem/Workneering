using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workneering.User.Application.Services.DbQueryService;

namespace Workneering.User.Application
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddUserApplication(this IServiceCollection services)
        {
            services.AddSingleton<IDbQueryService, DbQueryService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}