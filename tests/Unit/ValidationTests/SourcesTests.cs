using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using Models;
using Shouldly;
using Xunit;

namespace Geekiam.ValidationTests;

public class SourcesTests
{
    [Theory]
    [ClassData(typeof(SourcesTestData))]
    public void ShouldHaveValidationErrors(Sources source, int expectedResultCount, string reason)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(source, null, null);

        Validator.TryValidateObject(source, context, results, true).ShouldBeFalse();
        results.Count.ShouldBe(expectedResultCount, reason);
    }
}

public class SourcesTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            Builder<Sources>.CreateNew()
                .With(x => x.Domain = "test.com")
                .With(x => x.Name = "test.com")
                .Build(),
            2, "Domain and Name have the same values and Domain is not an absolute URL"
        };
        
        yield return new object[]
        {
            Builder<Sources>.CreateNew()
                .With(x => x.Domain = "test.com")
                .With(x => x.Name = "test")
                .Build(),
            1, "Domain is not an absolute URL"
        };
        
        yield return new object[]
        {
            Builder<Sources>.CreateNew()
                .With(x => x.Domain = "https://test.com")
                .With(x => x.Name = "test")
                .With(x => x.FeedUrl = "https://test.com")
                .Build(),
            3, "Domain is the same as FeedLink"
        };
        
        yield return new object[]
        {
            Builder<Sources>.CreateNew()
                .With(x => x.Domain = "https://test.com")
                .With(x => x.Name = "test")
                .With(x => x.FeedUrl = "https://test1.com")
                .Build(),
            2, "FeedLink should be relative"
        };
        
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  
}
    