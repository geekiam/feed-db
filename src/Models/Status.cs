using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public class Status : ValueListEntity, IValidatableObject
{
    public virtual ICollection<Sources> Sources { get; set; }
    
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Models.StatusNameRequired);
    }
}