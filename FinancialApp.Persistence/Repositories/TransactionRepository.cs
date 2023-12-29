using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Domain;
using FinancialApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Persistence.Repositories;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly AppDbContext _context;
    public TransactionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Transaction>> GetAsync(string userId)
    {
        return await _context.Set<Transaction>().Where(transaction => transaction.UserId == userId).AsNoTracking().ToListAsync();
    }
}
