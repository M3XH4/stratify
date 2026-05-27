namespace KPI.Core.Entities;

public class AuditLog : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Action { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public string? Details { get; set; }
}
