namespace KPI.Core.Entities;

public class KpiApproval : BaseEntity
{
    public int KpiId { get; set; }
    public Kpi Kpi { get; set; } = null!;
    public int ApprovedById { get; set; }
    public User ApprovedBy { get; set; } = null!;
    public string? Notes { get; set; }
}
