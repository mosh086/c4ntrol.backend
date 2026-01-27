namespace C4.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserGetAllResponse : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
