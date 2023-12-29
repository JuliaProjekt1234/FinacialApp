using FinancialApp.Application.Contracts.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinancialApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<ILoggedUserService, LoggedUserService>();
        return services;
    }
}
