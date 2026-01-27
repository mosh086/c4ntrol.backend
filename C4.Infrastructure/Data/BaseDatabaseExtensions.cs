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
        builder.Entity<UserEntity>().ToTable("Users", "sec");
        //builder.Entity<AppUserEntity>().ToTable("Users", "Security");

        builder.Entity<UserClaimEntity>().ToTable("UserClaims", "sec");
        //builder.Entity<AppUserClaimEntity>().ToTable("UserClaims", "Security");

        builder.Entity<UserLoginEntity>().ToTable("UserLogins", "sec");
        //builder.Entity<AppUserLoginEntity>().ToTable("UserLogins", "Security");

        builder.Entity<UserRoleEntity>().ToTable("UserRoles", "sec");
        //builder.Entity<AppUserRoleEntity>().ToTable("UserRoles", "Security");

        builder.Entity<UserTokenEntity>().ToTable("UserTokens", "sec");
        //builder.Entity<AppUserTokenEntity>().ToTable("UserTokens", "Security");

        builder.Entity<RoleEntity>().ToTable("Roles", "sec");
        //builder.Entity<AppRoleEntity>().ToTable("Roles", "Security");

        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "sec");
        //builder.Entity<AppRoleClaimEntity>().ToTable("RoleClaims", "Security");
        return builder;
    }
}