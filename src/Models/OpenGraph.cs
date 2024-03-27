using Models;
using Threenine.Models;

namespace Geekiam.Persistence.Models;

public sealed class OpenGraph : BaseEntity
{
    public Guid PostId { get; set; }
    public Posts Post { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string SiteName { get; set; }
}