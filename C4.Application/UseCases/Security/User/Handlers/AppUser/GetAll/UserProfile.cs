using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
        // Add other mappings as needed
    }
}