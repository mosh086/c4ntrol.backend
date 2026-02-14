using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Common.Repository;
using C4.Infrastructure.Data;
using C4.Infrastructure.Exceptions;
using C4.Infrastructure.Identity.Entities;

namespace C4.Infrastructure.UseCases.Security.User.Repositories;

public class UserRoleRepository : PivotRepository<AppUserRoleEntity>, IUserRoleRepository
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    public UserRoleRepository(C4ntrolDbContext context, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager) : base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public override async Task<AppUserRoleEntity> AddAsync(AppUserRoleEntity entity, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(entity.UserId.ToString());
        if (user == null)
            throw new InfraException("User not found");

        var role = await _roleManager.FindByIdAsync(entity.RoleId.ToString());
        if (role == null)
            throw new InfraException("Role not found");

        var userRoleEntity = new UserRoleEntity(entity.UserId, entity.RoleId);
        await Context.UserRoles.AddAsync(userRoleEntity);
        //entity.SetId(userRoleEntity.Id);
        return entity;
    }
}