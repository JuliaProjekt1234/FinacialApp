

using FinancialApp.Application.Contracts.Identity;
using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Queries.Commands;
using MediatR;

namespace FinancialApp.Application.Queries.Handlers;

public class GetTotalAmountCommandHandler : IRequestHandler<GetTotalAmountCommand, double>
{
    private readonly ILoggedUserService _loggedUserService;
    private readonly ITotalAmountRepository _totalAmountRepository;

    public GetTotalAmountCommandHandler(
        ILoggedUserService loggedUserService,
        ITotalAmountRepository totalAmountRepository)
    {
        _loggedUserService = loggedUserService;
        _totalAmountRepository = totalAmountRepository;
    }
    public async Task<double> Handle(GetTotalAmountCommand request, CancellationToken cancellationToken)
    {
        var userId = _loggedUserService.GetLoggedUserId();
        return (await _totalAmountRepository.GetAsync(userId)).TotalMoneyAmount;
    }
}
