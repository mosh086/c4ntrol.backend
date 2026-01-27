using C4.Application.UseCases.Security.Role.Repositories;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Common.Repository;
using C4.Infrastructure.Data;
using C4.Infrastructure.Identity.Entities;

namespace C4.Infrastructure.UseCases.Security.Role.Repositories;

public class RoleRepository : Repository<AppRoleEntity, long>, IRoleRepository
{
    private readonly RoleManager<RoleEntity> _roleManager;
    public RoleRepository(C4ntrolDbContext context, RoleManager<RoleEntity> roleManager) : base(context)
    {
        _roleManager = roleManager;
    }

    public async Task<AppRoleEntity> FindByNameAsync(string roleName, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
            return null;
        return role.AppRoleEntity();
    }
    public override async Task<AppRoleEntity> AddAsync(AppRoleEntity entity, CancellationToken cancellationToken)
    {
        RoleEntity roleEntity = new RoleEntity(entity.Name, entity.Title);
        await _roleManager.CreateAsync(roleEntity);
        entity.SetId(roleEntity.Id);
        return entity;
    }
}


public class RoleClaimRepository : Repository<AppRoleClaimEntity, int>, IRoleClaimRepository
{
    public RoleClaimRepository(C4ntrolDbContext context) : base(context)
    {
    }
}