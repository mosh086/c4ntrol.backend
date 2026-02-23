using Powdernaut.Application.UseCases.Security.User.Handlers.AppUser.GetAll;
using Powdernaut.Application.UseCases.Security.User.Handlers.AppUser.GetById;

namespace Powdernaut.WebApi.Controllers.Security;

public class UserController : AuthorizationController
{
    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserGetAllRequest, List<UserGetAllResponse>>(new UserGetAllRequest());

    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserGetByIdRequest, UserGetByIdResponse>(new UserGetByIdRequest(entityId));
}