using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Workneering.Message.Application
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddProjectApplication(this IServiceCollection services)
        {
            //services.AddSingleton<IDbQueryService, DbQueryService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}