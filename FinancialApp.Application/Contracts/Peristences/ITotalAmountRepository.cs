
using FinancialApp.Domain;

namespace FinancialApp.Application.Contracts.Peristences;

public interface ITotalAmountRepository : IGenericRepository<TotalAmount>
{
    public Task DecreaseTotalAmount(string userId, double amount);
    public Task<TotalAmount> GetAsync(string userId);

}
