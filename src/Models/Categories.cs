using System.ComponentModel.DataAnnotations;
using Geekiam.Persistence.Models;
using Threenine.Models;

namespace Models;

public sealed class Categories : BaseEntity, IValidatableObject
{
    public string Name { get; set; } = null!;


    public ICollection<SourceCategory> Sources { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.SourceNameIsRequired);
    }
}