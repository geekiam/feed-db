using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Threenine.Models;

namespace Models;

public partial class Sources : BaseEntity, IValidatableObject
{
    public string Identifier { get; set; }
    public string Name { get; set; }
    
    public string Description { get; set; }
    public string Domain { get; set; }
    public string FeedUrl { get; set; }
    public string Protocol { get; set; }
    
    public int StatusId { get; set; }
    public virtual Status Status { get; set; }
    
    public virtual ICollection<Posts> Posts { get; set; }
    
    
    public override string ToString()
    {
        return $"{Protocol}://{Domain}{FeedUrl}";
    }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Models.SourceNameIsRequired);
        
        if (Name.Equals(Domain))
        {
            yield return new ValidationResult(Models.NameCannotBeDomain);
        }

        if(string.IsNullOrEmpty(FeedUrl))
            yield return new ValidationResult(Models.FeedUrlIsRequired);
        
        if (FeedUrl.Equals(Domain))
        {
            yield return new ValidationResult(Models.DomainCannotBeFeedUrl);
        }
        
        if (!domainNameRegex().Match(Domain).Success)
        {
            yield return new ValidationResult(Models.InvalidDomainName);
        }
        
        if (!feedUrlRegex().Match(FeedUrl).Success)
        {
            yield return new ValidationResult(Models.RelativePathRequired);
        }
    }

   
    [GeneratedRegex("\\A([a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,}\\Z", RegexOptions.IgnoreCase,  "en-GB")]
    private static partial Regex domainNameRegex();
    
    
    [GeneratedRegex("^[^\\/]+\\/[^\\/].*$|^\\/[^\\/].*$", RegexOptions.IgnoreCase, "en-GB")]
    private static partial Regex feedUrlRegex();
}
