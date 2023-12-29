using FinancialApp.Domain;
using FinancialApp.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Persistence.DatabaseContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TotalAmount> TotalAmounts { get; set; }
}
