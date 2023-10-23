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

    public string Protocol { get; set; } = null!;

    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;
    

  
    public ICollection<SourceCategory> Categories { get; set; } = null!;



    public override string ToString()
    {
        return $"{Protocol}://{Domain}";
    }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.SourceNameIsRequired);

        if (string.IsNullOrEmpty(Domain))
            yield return new ValidationResult(Resources.InvalidDomainName);
        
        if (Name.Equals(Domain, StringComparison.InvariantCulture))
           yield return new ValidationResult(Resources.NameCannotBeDomain);
        

       
        
        if (!Regex.Match(Domain,RegularExpressions.DomainName, RegexOptions.IgnoreCase).Success)
        {
            yield return new ValidationResult(Resources.InvalidDomainName);
        }
        
        
    }

    
}
