using C4.Infrastructure.Identity.Entities;

namespace C4.Infrastructure.Identity.Polymorphism;

public class AppUserClaimsFactory : UserClaimsPrincipalFactory<UserEntity, RoleEntity>
{
    public AppUserClaimsFactory(
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager,
        IOptions<IdentityOptions> options)
        : base(userManager, roleManager, options)
    {
    }

    protected override Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {
        return base.GenerateClaimsAsync(user);
    }
}