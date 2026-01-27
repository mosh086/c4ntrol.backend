using C4.Application.UseCases.Security.Role.Repositories;
using C4.Application.UseCases.Security.User.Repositories;
using C4.Infrastructure.Identity.Entities;
using C4.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace C4.Infrastructure.Identity.Repositories;

public interface IIdentityService
{
    public UserManager<UserEntity> UserManager { get; }
    public RoleManager<RoleEntity> RoleManager { get; }
    public SignInManager<UserEntity> SignInManager { get; }

    public IAuthorizationService AuthorizationService { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }

    public IUserRepository UserRepository { get; }
    public IUserLoginRepository UserLoginRepository { get; }
    public IUserTokenRepository UserTokenRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ITokenService TokenService { get; }

    Task<AuthResponse> LoginAsync(UserEntity entity);
    Task LogoutAsync();
}
