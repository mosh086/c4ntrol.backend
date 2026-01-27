using C4.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace C4.Infrastructure.Data;

public class C4ntrolDbContext : BaseDatabaseContext
{
    public C4ntrolDbContext(DbContextOptions<C4ntrolDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        //configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        //configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddAuditableShadowProperties<long>();
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
