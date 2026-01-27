using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Common.Repository;
using C4.Infrastructure.Data;

namespace C4.Infrastructure.UseCases.Security.User.Repositories;

public class UserTokenRepository : Repository<AppUserTokenEntity, long>, IUserTokenRepository
{
    public UserTokenRepository(C4ntrolDbContext context) : base(context)
    {
    }
}
