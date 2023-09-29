using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Message.Infrustructure.Persistence;

namespace Workneering.Message.Infrustructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MessagesDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MessagesDbContext).Assembly.FullName)));
            return services;
        }
    }
}
