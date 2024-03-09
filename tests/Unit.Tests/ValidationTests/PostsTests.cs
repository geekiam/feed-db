using System.Collections;
using System.ComponentModel.DataAnnotations;
using FizzWare.NBuilder;
using Models;
using Shouldly;

namespace Geekiam.ValidationTests;

public class PostsTests
{
    [Theory]
    [ClassData(typeof(PostsTestData))]
    public void ShouldHaveValidationErrors(Posts source, int expectedResultCount, string reason)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(source, null, null);

        Validator.TryValidateObject(source, context, results, true).ShouldBeFalse();
        results.Count.ShouldBe(expectedResultCount, reason);
    }
}

public class PostsTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // Test Title is required
        yield return new object[]
        {
            Builder<Posts>.CreateNew()
                .With(x => x.Title = string.Empty)
                .With(x => x.Permalink = "https://test.com")
                .Build(),
            1, "Posts should have a title"
        };
        
        // Test Permalink is a invalid url
        yield return new object[]
        {
            Builder<Posts>.CreateNew()
                .With(x => x.Title = "test")
                .With(x => x.Permalink = "test")
                .Build(),
            1, "Perma link should be a valid URL"
        };

       

    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  
}