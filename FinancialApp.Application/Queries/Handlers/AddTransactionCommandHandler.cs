using AutoMapper;
using FinancialApp.Application.Contracts.Identity;
using FinancialApp.Application.Contracts.Services;
using FinancialApp.Application.Exceptions;
using FinancialApp.Application.Queries.Commands;
using FinancialApp.Application.Queries.Commands.Validators;
using FinancialApp.Domain;
using MediatR;


namespace FinancialApp.Application.Queries.Handlers;

public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand>
{
    private readonly IMapper _mapper;
    private readonly ILoggedUserService _loggedUserService;
    private readonly IAddTransactionService _addTransactionService;


    public AddTransactionCommandHandler(
        IMapper mapper,
        ILoggedUserService loggedUserService,
        IAddTransactionService addTransactionService
    )
    {
        _mapper = mapper;
        _loggedUserService = loggedUserService;
        _addTransactionService = addTransactionService;
    }
    public async Task Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddTransactionCommandValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.Errors.Any()) throw new BadRequestException("Invalid data", validatorResult);

        var transaction = _mapper.Map<Transaction>(request.TransactionToAddDto);
        transaction.UserId = _loggedUserService.GetLoggedUserId();
        await _addTransactionService.AddTransactionAsync(transaction);
    }
}
