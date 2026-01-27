namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserCreateRequest : RequestModel<UserCreateResponse>
{
    public string Name { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public string PersonalCode { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}