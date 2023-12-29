
using FluentValidation.Results;

namespace FinancialApp.Application.Exceptions;

public class BadRequestException : Exception
{
    public List<string> ValidationErrors = new();
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors.Concat(validationResult.Errors.Select(error => error.ErrorMessage));
    }

    public BadRequestException(string message) : base(message)
    {
    }
}
