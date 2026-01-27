using C4.Application.UseCases.Security.User.Handlers.AppUser.GetById;
using C4.Domain.UseCases.Security;
using C4.Domain.UseCases.Security.Parameters;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, AppUserCreateParameters>().ReverseMap();
        CreateMap<UserCreateRequest, AppUserEntity>().ReverseMap();
    }
}