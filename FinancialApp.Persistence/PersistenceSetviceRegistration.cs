using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Contracts.Services;
using FinancialApp.Persistence.DatabaseContext;
using FinancialApp.Persistence.Repositories;
using FinancialApp.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialApp.Persistence;

public static class PersistenceSetviceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AppDbConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITotalAmountRepository, TotalAmountRepository>();
        services.AddScoped<IAddTransactionService, AddTransactionService>();
        return services;
    }
}
