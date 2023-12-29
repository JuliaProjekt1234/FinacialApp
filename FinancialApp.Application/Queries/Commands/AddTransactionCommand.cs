using FinancialApp.Application.Queries.Dtos;
using MediatR;

namespace FinancialApp.Application.Queries.Commands;

public class AddTransactionCommand : IRequest
{
    public TransactionToAddDto TransactionToAddDto { get; set; }

    public AddTransactionCommand(TransactionToAddDto transactionToAddDto)
    {
        TransactionToAddDto = transactionToAddDto;
    }
}
