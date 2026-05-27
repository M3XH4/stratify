namespace KPI.Core.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Kpi> Kpis { get; set; } = new List<Kpi>();
}
