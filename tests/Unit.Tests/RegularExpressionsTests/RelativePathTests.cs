using System.Collections;
using System.Text.RegularExpressions;
using Geekiam.Persistence.Models;
using Shouldly;

namespace AmeritFleet.Auth.Roles.Unit.Tests.RegularExpressionsTests;

public class RelativePathTests
{
    [Theory]
    [ClassData(typeof(RelativePathTestData))]
    public void Should_be_Relative_path(string path, bool expectedResult)
    {
        var result = Regex.IsMatch(path, RegularExpressions.RelativeUrlPath);
        result.ShouldBe(expectedResult);
    }
}

public class RelativePathTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ["/test", true];
        yield return ["test/feed.xml", true];
        yield return ["/some-random-permalink", true];
        yield return ["/feed/", true];
        yield return ["garywoodfine.com", false];
        yield return ["https://threenine.co.uk", false];
        yield return ["ftp://threenine.co.uk", false];
        yield return ["/test-1234-test--3", true];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}