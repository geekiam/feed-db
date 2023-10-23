using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public sealed class Posts: BaseEntity, IValidatableObject
{
    public string Title { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Permalink { get; set; } = null!;
    public DateTime Published { get; set; }
    
    public Feeds Feed { get; set; } = null!;
    
    public Guid FeedId { get; set; }
    
    
    
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