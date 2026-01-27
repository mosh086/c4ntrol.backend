using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.Role.Repositories;

public interface IRoleRepository : IRepository<AppRoleEntity, long>
{
    Task<AppRoleEntity> FindByNameAsync(string roleName, CancellationToken cancellationToken);
}