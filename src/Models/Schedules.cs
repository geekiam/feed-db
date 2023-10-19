using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Models;

public sealed class Schedules : BaseEntity
{
    public Guid SourceId { get; set; }
    public Sources Source { get; set; } = null!;

    public int  ScheduleTypeId { get; set; }
    public ScheduleTypes ScheduleTypes { get; set; } = null!;

    public bool Active { get; set; }

    
   
}