

using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Exceptions;
using FinancialApp.Domain;
using FinancialApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Persistence.Repositories;

public class TotalAmountRepository : GenericRepository<TotalAmount>, ITotalAmountRepository
{
    private readonly AppDbContext _context;
    public TotalAmountRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task DecreaseTotalAmount(string userId, double amount)
    {
        var userTotalAmount =
            await GetAsync(userId);
        var oldTotalAmount = userTotalAmount.TotalMoneyAmount;
        userTotalAmount.TotalMoneyAmount -= amount;
        if (userTotalAmount.TotalMoneyAmount < 0) throw new TotalAmountIsTooSmallException(oldTotalAmount, amount);

        await UpdateAsync(userTotalAmount);
    }

    public async Task<TotalAmount> GetAsync(string userId)
    {
        return await _context.Set<TotalAmount>().FirstOrDefaultAsync(totalAmount => totalAmount.UserId == userId);
    }
}