

using MediatR;

namespace FinancialApp.Application.Queries.Commands;

public class DeleteTransactionCommand : IRequest
{
    public int TransactionId { get; }
    public DeleteTransactionCommand(int transactionId)
    {
        TransactionId = transactionId;
    }
}
