using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workneering.Base.Application.Common.RedisCache.Extensions;
using Workneering.Base.Application.Common.RedisCache.Interfaces;
using Workneering.Base.Application.Common.RedisCache.Services;

namespace Workneering.Base.Application.Behaviors.MediatR.Caching;

public class ResetCacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public ResetCacheBehaviour(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_configuration.GetRedisCasheConfig().Enabled || !typeof(IResetCacheCommand).IsAssignableFrom(request.GetType()!))
            return await next();

        var cacheService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
        var response = await next();
        var key = GetKey(request);
        await cacheService.ResetCacheResponseAsync(key, cancellationToken);
        return response;
    }

    private string GetKey(TRequest request)
        => request.GetType().FullName?.Split(".Commands.")[0] + ".Queries.";
}