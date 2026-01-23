namespace C4.Domain.Common;

public class Audit
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime LastUpdateAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
