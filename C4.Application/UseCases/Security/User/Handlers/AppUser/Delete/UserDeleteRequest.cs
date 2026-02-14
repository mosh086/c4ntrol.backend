namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Delete;

public class UserDeleteRequest : RequestModel<UserDeleteResponse>
{
    public Guid EntityId { get; set; }

    public UserDeleteRequest(Guid entityId)
    {
        EntityId = entityId;
    }
}
