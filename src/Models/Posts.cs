using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public class Posts: BaseEntity, IValidatableObject
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Permalink { get; set; }
    public DateTime Published { get; set; }
    
    public virtual Sources Source { get; set; }
    
    public Guid SourceId { get; set; }
    
    
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Title))
        {
            yield return new ValidationResult(Resources.NameRequired);
        }
        
        if (!Uri.IsWellFormedUriString(Permalink, UriKind.Absolute))
        {
            yield return new  ValidationResult(Resources.InvalidUrl);
        }
    }
}