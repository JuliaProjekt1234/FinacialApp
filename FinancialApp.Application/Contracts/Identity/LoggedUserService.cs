using Microsoft.AspNetCore.Http;

namespace FinancialApp.Application.Contracts.Identity;

public class LoggedUserService: ILoggedUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetLoggedUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value;
    }
}
