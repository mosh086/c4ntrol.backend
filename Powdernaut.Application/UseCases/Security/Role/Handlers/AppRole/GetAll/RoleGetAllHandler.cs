using Powdernaut.Application.UseCases.Security.Role.Repositories;
using Powdernaut.Domain.UseCases.Security;

namespace Powdernaut.Application.UseCases.Security.Role.Handlers.AppRole.GetAll;

public class RoleGetAllHandler : Handler<RoleGetAllRequest, List<RoleGetAllResponse>>
{
    private readonly IRoleRepository _repository;
    public RoleGetAllHandler(ProviderServices providerServices, IRoleRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<RoleGetAllResponse>> Handle(RoleGetAllRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.GetAsync(cancellationToken);
            var result = ProviderServices.Mapper.Map<AppRoleEntity, RoleGetAllResponse>(data);
            return result.ToList();
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
