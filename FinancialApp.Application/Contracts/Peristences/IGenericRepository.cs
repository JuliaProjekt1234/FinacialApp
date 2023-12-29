using FinancialApp.Domain.Common;

namespace FinancialApp.Application.Contracts.Peristences;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> FindAsync(int id);
    Task<IReadOnlyList<T>> GetAsync();
}
