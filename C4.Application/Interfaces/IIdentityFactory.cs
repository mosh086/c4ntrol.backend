using C4.Application.Providers.Scrutor;
using C4.Domain.UseCases.Security;

namespace C4.Application.Interfaces;

public interface IIdentityFactory : IScopeLifeTime
{
    string PasswordHash(AppUserEntity entity, string password);
    bool VerifyHashedPassword(AppUserEntity entity, string passwordHash, string password);
    string ConcurrencyStamp(string password);
    string SecurityStamp(string password);
}
