using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Workneering.Message.Application.Services.DbQueryService;


namespace Workneering.Message.Application
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddMessageApplication(this IServiceCollection services)
        {
            services.AddSingleton<IDbQueryService, DbQueryService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}