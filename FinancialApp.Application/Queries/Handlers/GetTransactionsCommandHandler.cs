using AutoMapper;
using FinancialApp.Application.Contracts.Identity;
using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Queries.Commands;
using FinancialApp.Application.Queries.Dtos;
using MediatR;

namespace FinancialApp.Application.Queries.Handlers
{
    public class GetTransactionsCommandHandler : IRequestHandler<GetTransactionsCommand, List<TransactionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsCommandHandler(
            IMapper mapper,
            ILoggedUserService loggedUserService,
            ITransactionRepository transactionRepository
        )
        {
            _mapper = mapper;
            _loggedUserService = loggedUserService;
            _transactionRepository = transactionRepository;
        }
        public async Task<List<TransactionDto>> Handle(GetTransactionsCommand request, CancellationToken cancellationToken)
        {
            var loggedUserId = _loggedUserService.GetLoggedUserId();
            var transactions = await _transactionRepository.GetAsync(loggedUserId);
            return _mapper.Map<List<TransactionDto>>(transactions);
        }
    }
}
