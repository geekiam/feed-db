using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Geekiam.Persistence;

public static class Initialiser
{
    public static async Task FeedsDatabaseInitialiseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<FeedsContext>();
        await context.MigrateAsync();
    }

    public static void FeedsDatabaseInitialise(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<FeedsContext>();
        context.Migrate();
    }
}