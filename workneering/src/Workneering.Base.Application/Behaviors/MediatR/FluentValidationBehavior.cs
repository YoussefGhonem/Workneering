using Workneering.Base.Application.GlobalExceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Workneering.Base.Application.Security;

namespace Workneering.Base.Application.Behaviors.MediatR;
// this a pipeline behavior in MediatR that is responsible for validating the request before it reaches the corresponding request handler.
// It intercepts the processing of requests and performs validation using a collection of validators.
public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IHttpContextAccessor _accessor;

    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IHttpContextAccessor accessor)
    {
        _validators = validators;
        _accessor = accessor;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)

    {
        if (!_validators.Any())
            return await next();
        // this for the incoming request. This context will be used to perform validation on the request object.
        var context = new ValidationContext<TRequest>(request);
        // It initializes a list to collect validation results.
        var validationResults = new List<ValidationResult>();
        // This line asynchronously runs validation logic for the request using all registered validators
        var validatorsResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var errorsDictionary = validatorsResult
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (!errorsDictionary.Any())
            return await next();

        await _accessor.SendBadRequestAndAbort("Validation errors", errorsDictionary);
        if (typeof(TResponse) == typeof(string))
            return (TResponse)Activator.CreateInstance(typeof(string), "".ToCharArray())!;
        if (typeof(TResponse) == typeof(Guid))
            return (TResponse)Activator.CreateInstance(typeof(Guid), Guid.Empty)!;
        return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
    }
}