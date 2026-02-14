using C4.Domain.Common;
using C4.Infrastructure.Identity.Entities.Parameters;

namespace C4.Infrastructure.Identity.Entities;

public class UserTokenEntity : IdentityUserToken<long>
{
    public string RefreshToken { get; private set; }
    public void SetToken(string refToken) => RefreshToken = refToken;

    public UserTokenEntity()
    {

    }
    public UserTokenEntity(UserTokenParameters parameters)
    {
        UserId = parameters.UserId;
        LoginProvider = parameters.LoginProvider;
        Name = parameters.Name;
        Value = parameters.Value;
        RefreshToken = parameters.RefreshToken;
    }
}
