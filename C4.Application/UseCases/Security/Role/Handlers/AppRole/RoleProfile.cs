using C4.Application.UseCases.Security.Role.Handlers.AppRole.GetAll;
using C4.Application.UseCases.Security.Role.Handlers.AppRole.GetById;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.Role.Handlers.AppRole;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<AppRoleEntity, RoleGetAllResponse>().ReverseMap();
        CreateMap<AppRoleEntity, RoleGetByIdResponse>().ReverseMap();
    }
}
