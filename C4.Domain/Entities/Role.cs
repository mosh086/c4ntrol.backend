namespace C4.Domain.Entities;

using C4.Domain.Common;

public class Role : Audit
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
