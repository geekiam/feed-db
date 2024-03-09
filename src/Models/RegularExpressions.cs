namespace Geekiam.Persistence.Models;

internal static class RegularExpressions
{
    internal const string DomainName = @"\A([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}\Z";
    internal const string RelativeUrlPath = @"^[^\/]+\/[^\/].*$|^\/[^\/].*$";
}