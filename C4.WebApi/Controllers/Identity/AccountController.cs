using Azure.Core;
using C4.Application.UseCases.Security.User.Handlers.AppUser.Create;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Data.Constants;
using C4.Infrastructure.Identity.Entities;
using C4.Infrastructure.Identity.Repositories;
using C4.WebApi.Models;

namespace C4.WebApi.Controllers.Identity;

public class AccountController : AuthorizationController
{
    private readonly IIdentityService _identityService;

    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest parameter)
    {
        var entity = ProviderServices.Mapper.Map<RegisterRequest, UserEntity>(parameter);
        var pass = _identityService.UserManager.PasswordHasher.HashPassword(entity, parameter.Password);
        await _identityService.UserManager.CreateAsync(entity, pass);

        await _identityService.UserManager.AddToRolesAsync(entity, parameter.Roles);

        return Ok(parameter);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpPut("DisActive")]
    public async Task<IActionResult> DisActive()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpGet("Profile")]
    public async Task<IActionResult> Profile()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpGet("admin-and-user")]
    [Authorize(Policy = Policies.AdminAccess)] // Multiple policies would require custom handler
    public async Task<IActionResult> AdminAccess()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpGet("UserAccess")]
    [Authorize(Policy = Policies.UserAccess)]
    public async Task<IActionResult> UserAccess()
    {
        await Task.CompletedTask;
        return Ok(true);
    }

    [HttpGet("CanUserAccessAdminFeatures")]
    public async Task<bool> CanUserAccessAdminFeatures()
    {
        var result = await _identityService.AuthorizationService.AuthorizeAsync(
            _identityService.HttpContextAccessor.HttpContext!.User,
            Policies.AdminAccess);

        return result.Succeeded;
    }
}
