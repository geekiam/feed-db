using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Geekiam.Persistence;
[ExcludeFromCodeCoverage]
internal class FeedsContextFactory : IDesignTimeDbContextFactory<FeedsDbContext>
{
    public FeedsDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<FeedsDbContext> dbContextOptionsBuilder =
            new();
        
        dbContextOptionsBuilder.UseNpgsql(ConnectionStringNames.LocalBuild);
        return new FeedsDbContext(dbContextOptionsBuilder.Options);
    }
}