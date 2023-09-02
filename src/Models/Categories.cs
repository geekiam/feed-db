using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public sealed class Categories : BaseEntity, IValidatableObject
{
    public string Name { get; set; } = null!;
    public string Permalink { get; set; } = null!;

    public ICollection<SourceCategory> Sources { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Uri.IsWellFormedUriString(Permalink, UriKind.Relative))
        {
            yield return new  ValidationResult($"{nameof(Permalink)} is not a valid url");
        }
    }
}