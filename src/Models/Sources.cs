using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Threenine.Models;

namespace Models;

public sealed class Sources : BaseEntity, IValidatableObject
{
    public string Identifier { get; set; } = null!;
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    public string Domain { get; set; } = null!;
    public string FeedUrl { get; set; } = null!;
    public string Protocol { get; set; } = null!;

    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;

    public int MediaTypeId { get; set; }
    public MediaTypes MediaType { get; set; } = null!;

    public ICollection<Posts> Posts { get; set; } = null!;
    public ICollection<SourceCategory> Categories { get; set; } = null!;

    public ICollection<Schedules> Schedules { get; set; } = null!;

    public override string ToString()
    {
        return $"{Protocol}://{Domain}{FeedUrl}";
    }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.SourceNameIsRequired);
        
        if (Name.Equals(Domain))
        {
            yield return new ValidationResult(Resources.NameCannotBeDomain);
        }

        if(string.IsNullOrEmpty(FeedUrl))
            yield return new ValidationResult(Resources.FeedUrlIsRequired);
        
        if (FeedUrl.Equals(Domain))
        {
            yield return new ValidationResult(Resources.DomainCannotBeFeedUrl);
        }
        
        if (!Regex.Match(Domain,RegularExpressions.DomainName, RegexOptions.IgnoreCase).Success)
        {
            yield return new ValidationResult(Resources.InvalidDomainName);
        }
        

        if (!Regex.Match(FeedUrl, RegularExpressions.RelativeUrlPath, RegexOptions.IgnoreCase).Success)
        {
            yield return new ValidationResult(Resources.RelativePathRequired);
        }
    }

    
}
