using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workneering.User.Infrastructure.Persistence;

public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDatabaseContext>
{
    private readonly IMediator _mediator;

    public UserDbContextFactory(IMediator mediator)
    {
        _mediator = mediator;
    }

    public UserDatabaseContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        var config = configBuilder.Build();
        var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<UserDatabaseContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var httpContextAccessor = new HttpContextAccessor();
        return new UserDatabaseContext(optionsBuilder.Options, httpContextAccessor, _mediator);
    }
}