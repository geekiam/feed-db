using Models;
using Threenine.Models;

namespace Geekiam.Persistence.Models;

public sealed class Twitter : BaseEntity
{
    public Guid PostId { get; set; }
    public Posts Post { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Site { get; set; }
    public string Creator { get; set; }
}