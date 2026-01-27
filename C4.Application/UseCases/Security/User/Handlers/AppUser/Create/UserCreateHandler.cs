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
            //  Check duplicate email, username, phonenumber, PersonalCode
            var entity = ProviderServices.Mapper.Map<UserCreateRequest, AppUserEntity>(request);
            _userRepository.SetPassword(request.Password);
            entity = await _userRepository.AddAsync(entity, cancellationToken);
            //  find role
            var roleEntity = await _roleRepository.FindByNameAsync(request.RoleName, cancellationToken);
            if (roleEntity is null)
            {
                roleEntity = new AppRoleEntity(request.RoleName, request.RoleName);
                roleEntity = await _roleRepository.AddAsync(roleEntity, cancellationToken);
            }
            //  create user role
            var userRoleEntity = new AppUserRoleEntity(entity.Id, roleEntity.Id);
            userRoleEntity = await _userRoleRepository.AddAsync(userRoleEntity, cancellationToken);
            //  save changes
            await _userRepository.SaveChangeAsync();
            await _userRepository.CommitTransactionAsync();
            return new UserCreateResponse($"Create Success User : {entity.DisplayName}");
        }
        catch (Exception)
        {

            await _userRepository.RollbackTransactionAsync();
            throw;
        }
    }
}