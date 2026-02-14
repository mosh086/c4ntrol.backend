using C4.Application.UseCases.Security.User.Handlers.AppUser.Create;
using C4.Application.UseCases.Security.User.Handlers.AppUser.Delete;
using C4.Application.UseCases.Security.User.Handlers.AppUser.GetAll;
using C4.Application.UseCases.Security.User.Handlers.AppUser.GetById;
using C4.Application.UseCases.Security.User.Handlers.AppUser.Update;
using C4.Domain.UseCases.Security;
using C4.Domain.UseCases.Security.Parameters;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, AppUserCreateParameters>().ReverseMap();
        CreateMap<UserCreateRequest, AppUserEntity>().ReverseMap();

        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
        CreateMap<AppUserEntity, UserGetByIdResponse>().ReverseMap();

        CreateMap<UserUpdateRequest, AppUserUpdateParameters>().ReverseMap();
        CreateMap<UserUpdateRequest, AppUserEntity>().ReverseMap();
        CreateMap<UserUpdateItemsRequest, AppUserEntity>().ReverseMap();

        CreateMap<UserDeleteRequest, UserDeleteRequest>().ReverseMap();
    }
}