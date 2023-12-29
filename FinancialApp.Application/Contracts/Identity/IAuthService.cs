using FinancialApp.Application.Models.Identity;

namespace FinancialApp.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Registration(RegistrationRequest request);
}
