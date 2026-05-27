using KPI.Core.Enums;

namespace KPI.Core.DTOs;

public record KpiDto(
    int Id,
    string Name,
    string Description,
    string Category,
    decimal TargetValue,
    decimal? ActualValue,
    string UnitOfMeasurement,
    int Weight,
    string DepartmentName,
    string? AssignedEmployeeName,
    DateOnly StartDate,
    DateOnly EndDate,
    KpiStatus Status);
