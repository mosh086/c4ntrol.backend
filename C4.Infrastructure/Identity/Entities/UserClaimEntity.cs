using C4.Domain.Common;

namespace C4.Infrastructure.Identity.Entities;

public class UserClaimEntity : IdentityUserClaim<long>
{
    public long Id { get; private set; }

    public UserClaimEntity()
    {
    }
}
