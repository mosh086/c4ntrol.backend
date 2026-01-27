using C4.Application.UseCases.Security.User.Handlers.AppUserToken.GetAll;

namespace C4.WebApi.Controllers.Security;

public class UserTokenController : AuthorizationController
{
    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserTokenGetRequest, List<UserTokenGetResponse>>(new UserTokenGetRequest());

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserTokenGetRequest, List<UserTokenGetResponse>>(new());
}
