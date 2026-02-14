using C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Get;

namespace C4.Application.UseCases.Security.User.Handlers.AppUserLogin;

public class UserLoginProfile : Profile
{
    public UserLoginProfile()
    {
        CreateMap<UserLoginGetRequest, UserLoginGetRequest>().ReverseMap();
        // Add other mappings as needed
    }
}
