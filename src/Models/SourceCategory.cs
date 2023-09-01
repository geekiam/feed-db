using Threenine.Models;

namespace Models;

public class SourceCategory : BaseEntity
{
    public Guid SourceId { get; set; }
    public Sources Source { get; set; }

    public Guid CategoryId { get; set; }
    public Categories Category { get; set; }
    
}