using C4.Application.Providers.Scrutor;
using C4.Infrastructure.Identity.Entities;
using C4.Infrastructure.Identity.Models;

namespace C4.Infrastructure.Identity.Repositories;

public interface ITokenService : IScopeLifeTime
{
    Task<AuthResponse> GenerateAccessTokenAsync(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}