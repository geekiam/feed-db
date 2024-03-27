using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Geekiam.Persistence;

[ExcludeFromCodeCoverage]
internal class FeedsContextFactory : IDesignTimeDbContextFactory<FeedsContext>
{
    public FeedsContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<FeedsContext> dbContextOptionsBuilder =
            new();

        dbContextOptionsBuilder.UseNpgsql(ConnectionStringNames.LocalBuild);
        return new FeedsContext(dbContextOptionsBuilder.Options);
    }
}