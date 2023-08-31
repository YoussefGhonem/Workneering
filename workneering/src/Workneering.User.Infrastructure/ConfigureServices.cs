using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workneering.User.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUserInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<UserDatabaseContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(UserDatabaseContext).Assembly.FullName)));
            return services;
        }
    }
}
