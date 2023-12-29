using FinancialApp.Domain;

namespace FinancialApp.Application.Contracts.Peristences;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    public Task<IReadOnlyList<Transaction>> GetAsync(string userId);
}
