using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IdentityDatabaseContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityDatabaseContext).Assembly.FullName)));
            return services;
        }
    }
}
