using Powdernaut.Application.UseCases.Security.User.Repositories;
using Powdernaut.Domain.UseCases.Security;

namespace Powdernaut.Application.UseCases.Security.User.Handlers.AppUser.GetById;

public class UserGetByIdHandler : Handler<UserGetByIdRequest, UserGetByIdResponse>
{
    private readonly IUserRepository _repository;
    public UserGetByIdHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserGetByIdResponse> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetAsync(request.EntityId, cancellationToken);

            return ProviderServices.Mapper.Map<AppUserEntity, UserGetByIdResponse>(entity);
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("", ex);
        }
    }
}
