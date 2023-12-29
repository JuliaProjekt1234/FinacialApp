using FinancialApp.Application.Contracts.Identity;
using FinancialApp.Application.Contracts.Peristences;
using FinancialApp.Application.Exceptions;
using FinancialApp.Application.Models.Identity;
using FinancialApp.Domain;
using FinancialApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace FinancialApp.Identity.Services;

public class AuthService : IAuthService
{
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITotalAmountRepository _totalAmountRepository;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AuthService(
        IOptions<JwtSettings> jwtSettings,
        UserManager<ApplicationUser> userManager,
        ITotalAmountRepository totalAmountRepository,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
        _totalAmountRepository = totalAmountRepository;
        _signInManager = signInManager;
    }
    public async Task<AuthResponse> Login(AuthRequest request)
    {

        var user = await _userManager.FindByNameAsync(request.UserName) ?? throw new Exception($"bad user {request.UserName}");
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded) throw new BadRequestException("Bad user data");

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        return new AuthResponse()
        {
            Id = user.Id,
            UserName = user.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        };

    }

    public async Task<RegistrationResponse> Registration(RegistrationRequest request)
    {

        var user = new ApplicationUser() { UserName = request.UserName };

        try { 
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) throw new BadRequestException($"The registration process failed");


        var totalAmount = new TotalAmount() { UserId = user.Id };
        await _totalAmountRepository.CreateAsync(totalAmount);

        return new RegistrationResponse() { UserId = user.Id };
        }
        catch(Exception ex) {
            throw;
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("uid", user.Id)
        }
        .Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCerditionals = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCerditionals);
    }

}
