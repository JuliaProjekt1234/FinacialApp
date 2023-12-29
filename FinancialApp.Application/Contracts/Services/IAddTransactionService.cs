namespace FinancialApp.Application.Contracts.Services;

public interface IAddTransactionService
{
    public Task AddTransactionAsync(Domain.Transaction transaction);
}
