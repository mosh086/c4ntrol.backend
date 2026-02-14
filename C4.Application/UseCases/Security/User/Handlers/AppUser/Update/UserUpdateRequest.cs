namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Update;

public class UserUpdateRequest : RequestModel<UserUpdateResponse>
{
    public List<UserUpdateItemsRequest> Items { get; set; }
}

public class UserUpdateItemsRequest()
{
    public Guid EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}