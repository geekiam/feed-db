﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Geekiam.Persistence.Models;
using Threenine.Models;

namespace Models;

public sealed class Sources : BaseEntity, IValidatableObject
{
    public string Identifier { get; set; } = null!;
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    public string Domain { get; set; } = null!;

    public string Protocol { get; set; } = null!;

    public int StatusId { get; set; } = 1;
    public Status Status { get; set; } = null!;

    public ICollection<Feeds> Feeds { get; set; }

    public ICollection<SourceCategory> Categories { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.SourceNameIsRequired);

        if (string.IsNullOrEmpty(Domain))
            yield return new ValidationResult(Resources.InvalidDomainName);

        if (Name.Equals(Domain, StringComparison.InvariantCulture))
            yield return new ValidationResult(Resources.NameCannotBeDomain);

        if (!Regex.Match(Domain, RegularExpressions.DomainName, RegexOptions.IgnoreCase).Success)
            yield return new ValidationResult(Resources.InvalidDomainName);
    }


    public override string ToString()
    {
        return $"{Protocol}://{Domain}";
    }
}