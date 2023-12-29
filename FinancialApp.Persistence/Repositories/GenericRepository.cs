using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Domain.Common;
using FinancialApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> FindAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
