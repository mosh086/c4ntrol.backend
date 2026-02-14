using C4.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Builder;

namespace C4.Infrastructure.Data;

public static class BaseDatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        //var initialiser = scope.ServiceProvider.GetRequiredService<InitializerSeedData>();
        //await initialiser.RunAsync();
    }

    public static ModelBuilder AddSecurityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<UserEntity>().ToTable("User", "sec");
        //builder.Entity<AppUserEntity>().ToTable("Users", "Security");

        builder.Entity<UserClaimEntity>().ToTable("UserClaim", "sec");
        //builder.Entity<AppUserClaimEntity>().ToTable("UserClaims", "Security");

        builder.Entity<UserLoginEntity>().ToTable("UserLogin", "sec");
        //builder.Entity<AppUserLoginEntity>().ToTable("UserLogins", "Security");

        builder.Entity<UserRoleEntity>().ToTable("UserRole", "sec");
        //builder.Entity<AppUserRoleEntity>().ToTable("UserRoles", "Security");

        builder.Entity<UserTokenEntity>().ToTable("UserToken", "sec");
        //builder.Entity<AppUserTokenEntity>().ToTable("UserTokens", "Security");

        builder.Entity<RoleEntity>().ToTable("Role", "sec");
        //builder.Entity<AppRoleEntity>().ToTable("Roles", "Security");

        builder.Entity<RoleClaimEntity>().ToTable("RoleClaim", "sec");
        //builder.Entity<AppRoleClaimEntity>().ToTable("RoleClaims", "Security");
        return builder;
    }
}