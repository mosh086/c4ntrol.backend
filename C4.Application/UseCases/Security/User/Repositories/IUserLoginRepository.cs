using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Repositories;

public interface IUserLoginRepository : IRepository<AppUserLoginEntity, long>
{
}