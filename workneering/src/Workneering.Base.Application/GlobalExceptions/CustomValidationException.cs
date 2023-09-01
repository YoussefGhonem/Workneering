using FluentValidation.Results;

namespace Workneering.Base.Application.GlobalExceptions;

// The 'ApplicationException' class is a base class provided by the.NET Framework for creating application-specific exceptions.
// It is intended to be used as a base class when defining custom exceptions that are specific to your application's domain or logic.
// Purpose: serves as a base class for creating exceptions that are specific to your application's needs.
// It provides a starting point for creating custom exception classes that can carry additional information or
// behavior beyond what is available in the base Exception class.


// The 'CustomValidationException' class is a custom exception class used to represent validation errors in an application.
public sealed class CustomValidationException : ApplicationException
{

    // This property allows access to the dictionary passed in through the constructor, providing information about the validation errors.
    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    public string ErrorMessage { get; }


    // It accepts an IReadOnlyDictionary<string, string[]> as a parameter, storing it in the ErrorsDictionary property
    // This allows the exception to carry information about the validation errors that occurred.
    public CustomValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base()
            => ErrorsDictionary = errorsDictionary;

    public CustomValidationException(string error)
            : base()
    {
        IReadOnlyDictionary<string, string[]> errors = new Dictionary<string, string[]>();

        // Define the key and values you want to append
        string key = "Validation Error";
        string[] newValues = { error };

        // Create a new dictionary and copy existing values
        var updatedErrors = new Dictionary<string, string[]>(errors);

        // Add or append the new values
        if (updatedErrors.ContainsKey(key))
        {
            updatedErrors[key] = updatedErrors[key].Concat(newValues).ToArray();
        }
        else
        {
            updatedErrors[key] = newValues;
        }
        ErrorsDictionary = updatedErrors;
    }

    public CustomValidationException(IList<ValidationFailure> validationFailures) : base()
    {
        ErrorsDictionary = validationFailures
         .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
         .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}

