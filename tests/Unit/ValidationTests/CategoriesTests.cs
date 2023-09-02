using System.Collections;
using System.ComponentModel.DataAnnotations;
using FizzWare.NBuilder;
using Models;
using Shouldly;

namespace Geekiam.ValidationTests;

public class CategoriesTests
{
    [Theory]
    [ClassData(typeof(CategoriesTestData))]
    public void ShouldHaveValidationErrors(Categories source, int expectedResultCount, string reason)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(source, null, null);

        Validator.TryValidateObject(source, context, results, true).ShouldBeFalse();
        results.Count.ShouldBe(expectedResultCount, reason);
    }
}

public class CategoriesTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
    
        yield return new object[]
        {
            Builder<Categories>.CreateNew()
                .With(x => x.Name = string.Empty)
                .Build(),
            1, "name is required"
        };
        



    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}