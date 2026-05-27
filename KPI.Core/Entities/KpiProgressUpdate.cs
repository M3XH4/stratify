namespace KPI.Core.Entities;

public class KpiProgressUpdate : BaseEntity
{
    public int KpiId { get; set; }
    public Kpi Kpi { get; set; } = null!;
    public int UpdatedById { get; set; }
    public User UpdatedBy { get; set; } = null!;
    public decimal ActualValue { get; set; }
    public string? Comment { get; set; }
}
