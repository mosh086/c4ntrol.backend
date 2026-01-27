using C4.Application.UseCases.Security.User.Handlers.AppUserLogin.GetAll;

namespace C4.WebApi.Controllers.Security;

public class UserLoginController : AuthorizationController
{
    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserLoginGetRequest, List<UserLoginGetResponse>>(new UserLoginGetRequest());

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserLoginGetRequest, List<UserLoginGetResponse>>(new());
}
