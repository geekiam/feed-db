using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public sealed class ScheduleTypes:  ValueListEntity, IValidatableObject
{
    public  ICollection<Schedules> Schedules { get; set; } = null!;
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Name))
            yield return new ValidationResult(Resources.NameRequired);
    }
}