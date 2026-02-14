using C4.Application.UseCases.Security.Role.Handlers.AppRole.GetAll;
using C4.Application.UseCases.Security.Role.Handlers.AppRole.GetById;

namespace C4.WebApi.Controllers.Security
{
    public class RoleController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get() => await RequestAsync<RoleGetAllRequest, List<RoleGetAllResponse>>(new RoleGetAllRequest());

        [HttpGet("{entityId}")]
        public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<RoleGetByIdRequest, RoleGetByIdResponse>(new RoleGetByIdRequest(entityId));
    }
}
