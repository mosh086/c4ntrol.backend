namespace C4.Domain.UseCases.Security;

[Table("RoleClaim", Schema = "sec"), Description("Role Claim Entity Model")]
public class AppRoleClaimEntity : BaseEntity<long>, IBaseEntity<long> //: BaseAuditableEntity<int>
{
    public long RoleId { get; private set; }
    public string? ClaimType { get; private set; }
    public string? ClaimValue { get; private set; }
}
