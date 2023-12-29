

using FluentValidation;

namespace FinancialApp.Application.Queries.Commands.Validators;

public class AddTransactionCommandValidator : AbstractValidator<AddTransactionCommand>
{
    public AddTransactionCommandValidator()
    {
        RuleFor(t => t.TransactionToAddDto.Title)
        .NotEmpty().WithMessage("is required")
        .NotNull()
        .MaximumLength(40).WithMessage("Maximum length is 40")
        .MinimumLength(1).WithMessage("Minimum length is 1");

        RuleFor(t => t.TransactionToAddDto.Amount)
        .NotEmpty().WithMessage("is required")
        .NotNull()
        .GreaterThan(0).WithMessage("Greater than is 40");
    }
}
