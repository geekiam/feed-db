namespace Geekiam.Persistence;

internal static class DefaultSchema
{
    internal const string Name = "feeds";
}

internal static class ConnectionStringNames
{
    /// <summary>
    ///     A default of localBuild is provided this can be any arbitrary value as this will ensure
    ///     the migrations are created using an ephemeral in memory database. If you want to use an actual database
    ///     to create migrations then this value can be changed to the name of a Connection string.
    /// </summary>
    internal static readonly string LocalBuild = "localBuild";

    internal static string Name => "Feeds";
}