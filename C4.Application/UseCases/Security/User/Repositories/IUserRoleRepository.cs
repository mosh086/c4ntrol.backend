using C4.Application.Common.Repository;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Repositories;

public interface IUserRoleRepository : IPivotRepository<AppUserRoleEntity> //IBaseRepository<AppUserRoleEntity, long>
{
}