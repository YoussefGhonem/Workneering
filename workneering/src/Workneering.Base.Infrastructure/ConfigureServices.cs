using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Base.Infrastructure.Persistence;
using Workneering.Base.Infrastructure.Persistence.Interceptors;

namespace Workneering.Base.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AdBaseInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            //services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            return services;
        }
    }
}
