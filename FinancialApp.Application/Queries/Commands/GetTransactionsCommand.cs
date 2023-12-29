using FinancialApp.Application.Queries.Dtos;
using MediatR;

namespace FinancialApp.Application.Queries.Commands;

public class GetTransactionsCommand : IRequest<List<TransactionDto>>;
