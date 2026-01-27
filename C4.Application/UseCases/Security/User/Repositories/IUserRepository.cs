using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Repositories;

public interface IUserRepository : IRepository<AppUserEntity, long>
{
    Task<AppUserEntity> GetByEmailAsync(string email);
    Task<AppUserEntity> GetByUsernameAsync(string username);
    void SetPassword(string password);
}
