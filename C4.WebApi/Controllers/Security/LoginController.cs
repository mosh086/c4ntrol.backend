using C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Get;

namespace C4.WebApi.Controllers.Security;

public class LoginController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post() => await RequestAsync<UserLoginGetRequest, List<UserLoginGetResponse>>(new UserLoginGetRequest());

}
