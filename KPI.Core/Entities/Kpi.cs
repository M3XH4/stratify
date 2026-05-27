using KPI.Core.Enums;

namespace KPI.Core.Entities;

public class Kpi : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal TargetValue { get; set; }
    public decimal? ActualValue { get; set; }
    public string UnitOfMeasurement { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public int? AssignedEmployeeId { get; set; }
    public User? AssignedEmployee { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public KpiStatus Status { get; set; } = KpiStatus.NotStarted;
    public bool IsArchived { get; set; }
    public ICollection<KpiProgressUpdate> ProgressUpdates { get; set; } = new List<KpiProgressUpdate>();
}
