using C4.Application.Common.Handlers;
using C4.Application.Providers;
using C4.Application.UseCases.Security.Role.Repositories;
using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserCreateHandler : Handler<UserCreateRequest, UserCreateResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IRoleRepository _roleRepository;
    public UserCreateHandler(ProviderServices providerServices, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository) : base(providerServices)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _roleRepository = roleRepository;
    }

    public override async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.BeginTransactionAsync();
            // TODO  Check duplicate email, username, phonenumber

            var entity = ProviderServices.Mapper.Map<UserCreateRequest, AppUserEntity>(request);
            _userRepository.SetPassword(request.Password);
            entity = await _userRepository.AddAsync(entity, cancellationToken);
            // find role
            
            var roleEntity = await _roleRepository.FindByNamesAsync(request.RoleName, cancellationToken);
            foreach (var role in roleEntity) 
            {
                if (role.Value is null)
                {
                    var newRoleEntity = new AppRoleEntity(role.Key);
                    newRoleEntity = await _roleRepository.AddAsync(newRoleEntity, cancellationToken);

                    //  create user role
                    var userRoleEntity = new AppUserRoleEntity(entity.Id, newRoleEntity.Id);
                    await _userRoleRepository.AddAsync(userRoleEntity, cancellationToken);
                }
                else
                {
                    var userRoleEntity = new AppUserRoleEntity(entity.Id, role.Value.Id);
                    await _userRoleRepository.AddAsync(userRoleEntity, cancellationToken);
                }
            }
            
            // save changes
            await _userRepository.SaveChangeAsync();
            await _userRepository.CommitTransactionAsync();
            return new UserCreateResponse($"Create Success User : {entity.UserName ?? entity.Name}");
        }
        catch (Exception)
        {

            await _userRepository.RollbackTransactionAsync();
            throw;
        }
    }
}