using C4.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C4.Infrastructure.Data.Configurations.Identity;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaimEntity>
{
    public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
    { }
}
