using C4.Domain.Common;

namespace C4.Infrastructure.Identity.Entities;

public class UserLoginEntity : IdentityUserLogin<long>
{
    // public long Id { get; private set; }

    public UserLoginEntity()
    {
    }
}