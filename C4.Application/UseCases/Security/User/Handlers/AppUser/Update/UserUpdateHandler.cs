using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Update;

public class UserUpdateHandler : Handler<UserUpdateRequest, UserUpdateResponse>
{
    private readonly IUserRepository _userRepository;
    public UserUpdateHandler(ProviderServices providerServices, IUserRepository userRepository) : base(providerServices)
    {
        _userRepository = userRepository;
    }
    public override async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.BeginTransactionAsync();
            foreach (var user in request.Items)
            {
                var userEntity = ProviderServices.Mapper.Map<UserUpdateItemsRequest, AppUserEntity>(user);
                var entity = await _userRepository.UpdateAsync(userEntity, cancellationToken);
            }

            await _userRepository.SaveChangeAsync();
            await _userRepository.CommitTransactionAsync();
            return new UserUpdateResponse($"Update Success User : ---");

        }
        catch (Exception ex)
        {
            throw new ApplicationException("", ex);
        }
    }
}