using C4.Application.UseCases.Security.User.Repositories;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Delete;

public class UserDeleteHandler : Handler<UserDeleteRequest, UserDeleteResponse>
{
    private readonly IUserRepository _repository;
    public UserDeleteHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserDeleteResponse> Handle(UserDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.RemoveAsync(request.EntityId, cancellationToken);
            await _repository.SaveChangeAsync();

            return new UserDeleteResponse();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("", ex);
        }
    }
}
