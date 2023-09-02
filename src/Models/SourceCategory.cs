using System;
using Threenine.Models;

namespace Models;

public sealed class SourceCategory : BaseEntity
{
    public Guid SourceId { get; set; }
    public Sources Source { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Categories Category { get; set; } = null!;
}