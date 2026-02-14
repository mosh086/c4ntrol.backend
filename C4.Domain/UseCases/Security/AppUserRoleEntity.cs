namespace C4.Domain.UseCases.Security;

[Table("UserRole", Schema = "sec"), Description("User Role Entity Model")]
public class AppUserRoleEntity //: BaseEntity<long>
{
    //public long Id { get; set; }
    [ForeignKey(nameof(AppUserEntity))]
    public virtual long UserId { get; set; }
    public virtual AppUserEntity AppUserEntity { get; set; }

    [ForeignKey(nameof(AppRoleEntity))]
    public virtual long RoleId { get; set; }
    public virtual AppRoleEntity AppRoleEntity { get; set; }

    public AppUserRoleEntity() { }
    public AppUserRoleEntity(long userId, long roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
    //public void SetId(long id) => Id = id;
}
