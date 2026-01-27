using C4.Application.UseCases.Security.User.Handlers.AppUserRole.GetAll;

namespace C4.WebApi.Controllers.Security;

public class UserRoleController : AuthorizationController
{
    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserRoleGetRequest, List<UserRoleGetResponse>>(new UserRoleGetRequest());

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserRoleGetRequest, List<UserRoleGetResponse>>(new());
}
