using MediatR;


namespace FinancialApp.Application.Queries.Commands;

public class GetTotalAmountCommand : IRequest<double>
{
}
