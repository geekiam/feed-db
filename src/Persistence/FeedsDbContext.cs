using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Threenine;
using Threenine.Configurations.PostgreSql;

namespace Geekiam.Persistence;

public class FeedsDbContext : BaseContext<FeedsDbContext>
{
    public FeedsDbContext(DbContextOptions<FeedsDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema.Name);
        modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
