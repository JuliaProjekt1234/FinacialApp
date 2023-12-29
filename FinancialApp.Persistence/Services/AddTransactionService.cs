using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Contracts.Services;
using FinancialApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace FinancialApp.Persistence.Services
{
    public class AddTransactionService : IAddTransactionService
    {
        private readonly AppDbContext _context;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITotalAmountRepository _totalAmountRepository;

        public AddTransactionService(AppDbContext context, ITransactionRepository transactionRepository, ITotalAmountRepository totalAmountRepository)
        {
            _context = context;
            _transactionRepository = transactionRepository;
            _totalAmountRepository = totalAmountRepository;
        }

        public async Task AddTransactionAsync(Domain.Transaction transaction)
        {
            using var transactionContext = await _context.Database.BeginTransactionAsync();

            try
            {
                await _transactionRepository.CreateAsync(transaction);
                await _totalAmountRepository.DecreaseTotalAmount(transaction.UserId, transaction.Amount);
                await transactionContext.CommitAsync();
            }
            catch (Exception ex)
            {
                await transactionContext.RollbackAsync();
                throw;
            }

        }

    }
}
