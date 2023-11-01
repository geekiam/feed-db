using System.ComponentModel.DataAnnotations;
using Geekiam.Persistence.Models;
using Threenine.Models;

namespace Models;

public sealed class Feeds : BaseEntity, IValidatableObject
{
    public Guid Id { get; set; }
    
    public Guid SourcesId { get; set; }
    public Sources Source { get; set; }
    public int MediaTypeId { get; set; }
    public MediaTypes MediaType { get; set; } = null!;
    
    public int StatusId { get; set; }
    public Status Status { get; set; }
    
 
    public string Path { get; set; } = null!;


    
    public  ICollection<Posts> Posts { get; set; } = null!;
    public ICollection<Schedules> Schedules { get; set; } = null!;
    

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Path))
            yield return new ValidationResult(Resources.FeedUrlIsRequired);
        
      
    }
}