using System.Collections;
using System.Text.RegularExpressions;
using Models;
using Shouldly;

namespace Geekiam.RegularExpressionsTests;

public class DomainNameTests
{
    [Theory]
    [ClassData(typeof(DomainNameTestData))]
    public void Should_be_Relative_path(string path, bool expectedResult)
    {
        var result = Regex.IsMatch(path, RegularExpressions.DomainName);
        result.ShouldBe(expectedResult);
    }
}

public class DomainNameTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "test.com", true };
        yield return new object[] { "https://test.com", false };
        yield return new object[] { "test.com/index.html", false };
        yield return new object[] { "test.co.uk", true };
        yield return new object[] { "test.io", true };
        yield return new object[] { "test.com.au", true };
        yield return new object[] { "test.gov", true };
        yield return new object[] { "test.gov.uk", true };
      
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}