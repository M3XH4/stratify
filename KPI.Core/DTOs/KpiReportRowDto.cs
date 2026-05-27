using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record KpiReportRowDto(
    int Id,
    string Name,
    string Department,
    string Category,
    decimal TargetValue,
    decimal? ActualValue,
    decimal PerformanceScore,
    DateOnly StartDate,
    DateOnly EndDate,
    KpiStatus Status);
