using Threenine.Models;

namespace Models;

public sealed class Schedules : BaseEntity
{
    public Guid FeedId { get; set; }
    public Feeds Feed { get; set; } = null!;

    public int ScheduleTypeId { get; set; }
    public ScheduleTypes ScheduleType { get; set; } = null!;

    public bool Active { get; set; }
}