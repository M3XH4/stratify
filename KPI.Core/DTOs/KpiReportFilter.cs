using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record KpiReportFilter(
    int? DepartmentId,
    DateOnly? StartDate,
    DateOnly? EndDate,
    KpiStatus? Status);
