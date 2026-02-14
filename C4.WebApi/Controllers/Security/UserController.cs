using C4.Application.UseCases.Security.User.Handlers.AppUser.Create;
using C4.Application.UseCases.Security.User.Handlers.AppUser.Delete;
using C4.Application.UseCases.Security.User.Handlers.AppUser.GetAll;
using C4.Application.UseCases.Security.User.Handlers.AppUser.GetById;
using C4.Application.UseCases.Security.User.Handlers.AppUser.Update;

namespace C4.WebApi.Controllers.Security;

public class UserController : AuthorizationController
{
    [HttpPost]
    public async Task<IActionResult> Create(UserCreateRequest request) => await RequestAsync<UserCreateRequest, UserCreateResponse>(request);

    [HttpPut]
    public async Task<IActionResult> Update(List<UserUpdateItemsRequest> request) => await RequestAsync<UserUpdateRequest, UserUpdateResponse>(new UserUpdateRequest { Items = request });

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(Guid entityId) => await RequestAsync<UserDeleteRequest, UserDeleteResponse>(new UserDeleteRequest(entityId));

    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserGetAllRequest, List<UserGetAllResponse>>(new UserGetAllRequest());

    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserGetByIdRequest, UserGetByIdResponse>(new UserGetByIdRequest(entityId));
}