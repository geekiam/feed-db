using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public sealed class Status : ValueListEntity, IValidatableObject
{
    public ICollection<Sources> Sources { get; set; } = null!;


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.NameRequired);
    }
}