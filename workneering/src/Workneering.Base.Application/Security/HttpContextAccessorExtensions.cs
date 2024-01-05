using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Workneering.Base.Application.GlobalExceptions;

namespace Workneering.Base.Application.Security;

public static class HttpContextAccessorExtensions
{
    public static async Task SendNotFoundAndAbort(this IHttpContextAccessor? accessor, string? message)
    {
        var response = new
        {
            title = "Not found",
            status = StatusCodes.Status404NotFound,
            detail = message,
        };
        if (accessor?.HttpContext == null || accessor.HttpContext.Response.HasStarted)
            throw new NotFoundException(JsonSerializer.Serialize(response));
        await accessor.HttpContext.SetResponseAndAbort(StatusCodes.Status404NotFound,
            JsonSerializer.Serialize(response));
    }

    public static async Task SendUnauthorizedAndAbort(this IHttpContextAccessor? accessor, string? message)
    {
        var response = new
        {
            title = "Unauthorized",
            status = StatusCodes.Status401Unauthorized,
            detail = message,
        };
        if (accessor?.HttpContext == null || accessor.HttpContext.Response.HasStarted)
            throw new UnauthorizedAccessException(JsonSerializer.Serialize(response));
        await accessor.HttpContext.SetResponseAndAbort(StatusCodes.Status401Unauthorized,
            JsonSerializer.Serialize(response));
    }

    public static async Task SendForbiddenAndAbort(this IHttpContextAccessor? accessor, string? message)
    {
        var response = new
        {
            title = "Forbidden",
            status = StatusCodes.Status403Forbidden,
            detail = message,
        };
        if (accessor?.HttpContext == null || accessor.HttpContext.Response.HasStarted)
            throw new ForbiddenException(JsonSerializer.Serialize(response));
        await accessor.HttpContext.SetResponseAndAbort(StatusCodes.Status403Forbidden,
            JsonSerializer.Serialize(response));
    }

    public static async Task SendBadRequestAndAbort(this IHttpContextAccessor? accessor, string message,
        Dictionary<string, string[]>? errors = default)
    {
        var response = new
        {
            title = "Bad request",
            status = StatusCodes.Status400BadRequest,
            detail = message,
            errors
        };
        if (accessor?.HttpContext == null || accessor.HttpContext.Response.HasStarted)
            throw new FluentValidationException(errors ?? new Dictionary<string, string[]>());
        await accessor.HttpContext.SetResponseAndAbort(StatusCodes.Status400BadRequest,
            JsonSerializer.Serialize(response));
    }

    public static async Task SendResponseAndAbort(this IHttpContextAccessor? accessor, int statusCode,
        object? response = default)
    {
        if (accessor?.HttpContext == null || accessor.HttpContext.Response.HasStarted)
            return;
        await accessor.HttpContext.SetResponseAndAbort(statusCode,
            JsonSerializer.Serialize(response));
    }

    private static async Task SetResponseAndAbort(this HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        //await context.Response.StartAsync(context.RequestAborted);
        await context.Response.WriteAsync(message, context.RequestAborted);
        //await context.Response.CompleteAsync();
        //context.Features.Get<IConnectionLifetimeFeature>()?.Abort();
        // context.Abort();
    }
}