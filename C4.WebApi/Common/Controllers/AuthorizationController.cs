using Microsoft.AspNetCore.Authorization;

namespace C4.WebApi.Common.Controllers;

[Authorize]
public abstract class AuthorizationController : BaseController
{

}