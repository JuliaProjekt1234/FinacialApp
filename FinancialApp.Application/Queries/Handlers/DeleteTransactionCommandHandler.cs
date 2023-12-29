using AutoMapper;
using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Queries.Commands;
using MediatR;
using System.Transactions;

namespace FinancialApp.Application.Queries.Handlers;

public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;

    public DeleteTransactionCommandHandler(
        ITransactionRepository transactionRepository
    )
    {
        _transactionRepository = transactionRepository;
    }
    public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.FindAsync(request.TransactionId);
        await _transactionRepository.DeleteAsync(transaction);
    }
}
