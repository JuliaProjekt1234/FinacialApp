using FinancialApp.Application.Contracts.Identity;
using FinancialApp.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(nameof(Login))]
        public async Task<AuthResponse> Login([FromBody] AuthRequest request)
        {
            return await _authService.Login(request);
        }

        [HttpPost(nameof(Registration))]
        public async Task<RegistrationResponse> Registration([FromBody] RegistrationRequest request)
        {
            return await _authService.Registration(request);
        }
    }
}
