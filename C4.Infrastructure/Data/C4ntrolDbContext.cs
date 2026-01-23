using C4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace C4.Infrastructure.Data;

public class C4ntrolDbContext : DbContext
{
    public C4ntrolDbContext(DbContextOptions<C4ntrolDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(C4ntrolDbContext).Assembly);
    }
}
