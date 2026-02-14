using C4.Application.UseCases.Security.Role.Repositories;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.Role.Handlers.AppRole.GetById;

public class RoleGetByIdHandler : Handler<RoleGetByIdRequest, RoleGetByIdResponse>
{
    private readonly IRoleRepository _repository;
    public RoleGetByIdHandler(ProviderServices providerServices, IRoleRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<RoleGetByIdResponse> Handle(RoleGetByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.GetAsNoTrackingAsync(request.EntityId, cancellationToken);
            var result = ProviderServices.Mapper.Map<AppRoleEntity, RoleGetByIdResponse>(data);
            return result;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
