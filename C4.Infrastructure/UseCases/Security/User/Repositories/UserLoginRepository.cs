using C4.Application.Providers.ObjectMapper;
using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Common.Repository;
using C4.Infrastructure.Data;
using C4.Infrastructure.Identity.Entities;

namespace C4.Infrastructure.UseCases.Security.User.Repositories;

public class UserLoginRepository : Repository<AppUserLoginEntity, long>, IUserLoginRepository
{
    private readonly UserManager<UserEntity> _userManager;
    public string Password { get; private set; }
    private readonly IObjectMapper _mapper;
    public UserLoginRepository(C4ntrolDbContext context, UserManager<UserEntity> userManager, IObjectMapper mapper) : base(context)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<AppUserEntity> GetByEmailAsync(string email)
    {
        var user = (await _userManager.FindByEmailAsync(email)).AppUserEntity();

        return user;
    }

    public async Task<AppUserEntity> GetByUsernameAsync(string username)
    {
        var user = (await _userManager.FindByNameAsync(username)).AppUserEntity();

        return user;
    }

    public void SetPassword(string password)
    {
        Password = password;
    }

}